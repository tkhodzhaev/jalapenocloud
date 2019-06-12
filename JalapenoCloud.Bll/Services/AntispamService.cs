using System;
using System.Linq;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Common.Messaging.Requests;
using JalapenoCloud.Common.Messaging.Responses;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Domain.Enums;

namespace JalapenoCloud.Bll.Services
{
    public class AntispamService
    {
        private ClientService _clientService;
        private ComplaintService _complaintService;
        private SettingService _settingService;
        private SmsHashService _smsHashService;
        private SpammerService _spammerService;
        private UserService _userService;
        private const string DateTimeFormat = "yyyy.MM.dd HH:mm:ss";

        public AntispamService()
        {
            _clientService = new ClientService();
            _complaintService = new ComplaintService();
            _settingService = new SettingService();
            _smsHashService = new SmsHashService();
            _spammerService = new SpammerService();
            _userService = new UserService();
        }

        public PublicKeyResponse PublicKey()
        {
            var service = new SettingService();
            string publicKey = service.GetDbSetting<string>(DbSettingKey.PublicKey);

            return new PublicKeyResponse()
            {
                PublicKey = publicKey,
                ErrorMessage = null,
                WasSuccessful = true
            };
        }

        public IsSpammerResponse IsSpammer(IsSpammerRequest request)
        {
            Client client = _clientService.GetById(request.ClientId);

            if (client == null || client.IsDeleted)
            {
                return new IsSpammerResponse()
                {
                    ErrorMessage = ServerErrors.NotAuthorizedRequest,
                    WasSuccessful = false
                };
            }

            User user = _userService.GetById(client.UserId);

            if (TrialAccessExpired(user))
            {
                return new IsSpammerResponse()
                {
                    ErrorMessage = ServerErrors.PaymentRequired,
                    WasSuccessful = false
                };
            }

            int senderIdTotalComplaintsLimit = _settingService.GetDbSetting<int>(DbSettingKey.SenderIdTotalComplaintsLimit);
            Spammer spammer = _spammerService.GetByFilter(new { SenderId = request.SenderId }).FirstOrDefault();
            bool isSenderIdSpammer = spammer != null && !spammer.IsDeleted && spammer.TotalComplaints > senderIdTotalComplaintsLimit;

            int smsHashTotalComplaintsLimit = _settingService.GetDbSetting<int>(DbSettingKey.SmsHashTotalComplaintsLimit);
            SmsHash smsHash = _smsHashService.GetByFilter(new { Hash = request.Hash }).FirstOrDefault();
            bool isHashSpammer = smsHash != null && !smsHash.IsDeleted && smsHash.TotalComplaints > smsHashTotalComplaintsLimit;

            bool isSpammer = isSenderIdSpammer || isHashSpammer;

            return new IsSpammerResponse()
            {
                IsSpammer = isSpammer,
                ErrorMessage = null,
                WasSuccessful = true
            };
        }

        private static bool TrialAccessExpired(User user)
        {
            return !user.UnlimitedAccess && user.ExpirationDate < DateTime.UtcNow;
        }

        public ComplainResponse Complain(ComplainRequest request)
        {
            Client client = _clientService.GetById(request.ClientId);

            if (client == null || client.IsDeleted)
            {
                return new ComplainResponse()
                {
                    ErrorMessage = ServerErrors.NotAuthorizedRequest,
                    WasSuccessful = false
                };
            }

            User user = _userService.GetById(client.UserId);

            if (TrialAccessExpired(user))
            {
                return new ComplainResponse()
                {
                    ErrorMessage = ServerErrors.PaymentRequired,
                    WasSuccessful = false
                };
            }

            long todayComplaintsCount = _complaintService.GetUserComplaintsCount(client.UserId, DateTime.UtcNow.Date, DateTime.UtcNow);
            long userComplaintsDailyLimit = _settingService.GetDbSetting<long>(DbSettingKey.UserComplaintsDailyLimit);

            if (todayComplaintsCount >= userComplaintsDailyLimit)
            {
                return new ComplainResponse()
                {
                    ErrorMessage = ServerErrors.TooManyComplaintsFromUser,
                    WasSuccessful = false
                };
            }

            if (!SenderIdIsValid(request.SenderId))
            {
                return new ComplainResponse()
                {
                    ErrorMessage = ServerErrors.InvalidRequest,
                    WasSuccessful = false
                };
            }

            DateTime utcNow = DateTime.UtcNow;
            ProcessSenderIdComplaint(request, client, utcNow);
            ProcessSmsHashComplaint(request, client, utcNow);

            return new ComplainResponse()
            {
                ErrorMessage = null,
                WasSuccessful = true
            };
        }

        public NotifyAboutPaymentResponse NotifyAboutPayment(NotifyAboutPaymentRequest request)
        {
            Client client = _clientService.GetById(request.ClientId);

            if (client == null || client.IsDeleted)
            {
                return new NotifyAboutPaymentResponse()
                {
                    ErrorMessage = ServerErrors.NotAuthorizedRequest,
                    WasSuccessful = false
                };
            }

            User user = _userService.GetById(client.UserId);
            SetUnlimitedAccess(user);

            user.PaymentInfo = request.PaymentInfo;
            user.Paid = true;
            user.PaymentDate = DateTime.UtcNow;
            _userService.Save(user);

            return new NotifyAboutPaymentResponse()
            {
                ErrorMessage = null,
                WasSuccessful = true
            };
        }

        private void SetUnlimitedAccess(User user)
        {
            user.ExpirationDate = null;
            user.UnlimitedAccess = true;
        }

        public RegisterClientResponse RegisterClient(RegisterClientRequest request)
        {
            //string id = GoogleApiService.GetUserIdByToken(request.Token);
            string email = null;
            string id = GoogleApiService.GetUserIdByJwt(request.Token, out email);

            if (string.IsNullOrEmpty(id))
            {
                return new RegisterClientResponse()
                {
                    ErrorMessage = ServerErrors.InvalidToken,
                    WasSuccessful = false
                };
            }

            User user = _userService.GetByFilter(new { GoogleId = id }).FirstOrDefault();
            DateTime utcNow = DateTime.UtcNow;

            if (user == null)
            {
                var trialDaysLimit = _settingService.GetDbSetting<int>(DbSettingKey.TrialDaysLimit);
                var isUnlimitedAccess = trialDaysLimit == 0;
                DateTime? expirationDate = isUnlimitedAccess ? (DateTime?)null : utcNow.AddDays(trialDaysLimit);

                user = new User
                {
                    GoogleId = id,
                    RegistrationDate = utcNow,
                    ExpirationDate = expirationDate,
                    UnlimitedAccess = isUnlimitedAccess,
                    PaymentInfo = null,
                    Paid = false,
                    PaymentDate = null,
                    Email = email
                };
                NotificationAndLogService.LogMessage(string.Format("New user Id: {0}, Email: {1}", id, email));

                _userService.Save(user);
            }
            else
                if (user.IsDeleted)
                {
                    return new RegisterClientResponse()
                    {
                        ErrorMessage = ServerErrors.UserBanned,
                        WasSuccessful = false
                    };
                }

            var client = new Client(request.ClientId)
            {
                UserId = user.Id,
                RegistrationDate = utcNow
            };

            _clientService.Save(client);

            return new RegisterClientResponse()
            {
                ErrorMessage = null,
                WasSuccessful = true,
                ExpirationDate = DateToString(user.ExpirationDate),
                UnlimitedAccess = user.UnlimitedAccess
            };
        }

        public RegisterClientResponse RegisterTestClient(RegisterClientRequest request)
        {
            var service = new SettingService();
            bool testMode = service.GetDbSetting<bool>(DbSettingKey.TestMode);

            if (!testMode)
            {
                return new RegisterClientResponse()
                {
                    ErrorMessage = ServerErrors.InvalidRequest,
                    WasSuccessful = false,
                    ExpirationDate = null
                };
            }

            string idFullString = string.Format("TEST:{0} Token:{1}", Guid.NewGuid(), request.Token);
            string id = idFullString.Length > 127 ? idFullString.Substring(0, 127) : idFullString;

            DateTime utcNow = DateTime.UtcNow;

            int trialDaysLimit = _settingService.GetDbSetting<int>(DbSettingKey.TrialDaysLimit);
            var isUnlimitedAccess = trialDaysLimit == 0;
            DateTime? expirationDate = isUnlimitedAccess ? (DateTime?)null : utcNow.AddDays(trialDaysLimit);

            var user = new User
            {
                GoogleId = id,
                RegistrationDate = utcNow,
                ExpirationDate = expirationDate,
                UnlimitedAccess = isUnlimitedAccess,
                PaymentInfo = null,
                Paid = false,
                PaymentDate = null,
                Email = null
            };

            _userService.Save(user);

            var client = new Client(request.ClientId)
            {
                UserId = user.Id,
                RegistrationDate = utcNow
            };

            _clientService.Save(client);

            return new RegisterClientResponse()
            {
                ErrorMessage = null,
                WasSuccessful = true,
                ExpirationDate = DateToString(user.ExpirationDate),
                UnlimitedAccess = user.UnlimitedAccess
            };
        }

        private void ProcessSenderIdComplaint(ComplainRequest request, Client client, DateTime utcNow)
        {
            Spammer spammer = _spammerService.GetByFilter(new { SenderId = request.SenderId }).FirstOrDefault();

            if (spammer == null)
            {
                spammer = new Spammer()
                {
                    SenderId = request.SenderId,
                    RegistrationDate = utcNow,
                    TotalComplaints = 0
                };
            }

            spammer.TotalComplaints++;
            string smsHash = string.IsNullOrWhiteSpace(request.Hash) ? spammer.Id.ToString() : request.Hash;

            var complaint = new Complaint()
            {
                Date = utcNow,
                SpammerId = spammer.Id,
                SmsHash = smsHash,
                UserId = client.UserId
            };

            _complaintService.Save(complaint);
            _spammerService.Save(spammer);
        }

        private void ProcessSmsHashComplaint(ComplainRequest request, Client client, DateTime utcNow)
        {
            if (SmsHashIsValid(request.Hash))
            {
                SmsHash smsHash = _smsHashService.GetByFilter(new { Hash = request.Hash }).FirstOrDefault();

                if (smsHash == null)
                {
                    smsHash = new SmsHash()
                    {
                        Hash = request.Hash,
                        RegistrationDate = utcNow,
                        TotalComplaints = 0
                    };
                }

                smsHash.TotalComplaints++;
                _smsHashService.Save(smsHash);
            }
        }

        private bool SenderIdIsValid(string senderId)
        {
            return !string.IsNullOrWhiteSpace(senderId);
        }

        private bool SmsHashIsValid(string smsHash)
        {
            return !string.IsNullOrWhiteSpace(smsHash);
        }

        private string DateToString(DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToString(DateTimeFormat) : null;
        }
    }
}