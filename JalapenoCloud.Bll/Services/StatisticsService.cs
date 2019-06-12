using System;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class StatisticsService
    {
        private ClientRepository _clientRepository;
        private ComplaintRepository _complaintRepository;
        private ExceptionLogRepository _exceptionLogRepository;
        private SmsHashRepository _smsHashRepository;
        private SpammerRepository _spammerRepository;
        private UserRepository _userRepository;

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public StatisticsService()
        {
            Init(DateTime.MinValue, DateTime.MaxValue);
        }

        public StatisticsService(DateTime periodStart, DateTime periodEnd)
        {
            Init(periodStart, periodEnd);
        }

        public long TotalClients()
        {
            long response = _clientRepository.GetTotalCount(this.PeriodStart, this.PeriodEnd, null);
            return response;
        }

        public long TotalComplaints()
        {
            long response = _complaintRepository.GetTotalCount(this.PeriodStart, this.PeriodEnd);
            return response;
        }

        public long TotalExceptions()
        {
            long response = _exceptionLogRepository.GetTotalCount(this.PeriodStart, this.PeriodEnd);
            return response;
        }

        public long TotalSmsHashes()
        {
            long response = _smsHashRepository.GetTotalCount(this.PeriodStart, this.PeriodEnd);
            return response;
        }

        public long TotalSpammers()
        {
            long response = _spammerRepository.GetTotalCount(this.PeriodStart, this.PeriodEnd, null);
            return response;
        }

        public long TotalUsers(bool? paid = null)
        {
            long response = _userRepository.GetTotalCount(this.PeriodStart, this.PeriodEnd, null, paid);
            return response;
        }

        private void Init(DateTime periodStart, DateTime periodEnd)
        {
            this.PeriodStart = periodStart;
            this.PeriodEnd = periodEnd;

            _clientRepository = new ClientRepository();
            _complaintRepository = new ComplaintRepository();
            _exceptionLogRepository = new ExceptionLogRepository();
            _smsHashRepository = new SmsHashRepository();
            _spammerRepository = new SpammerRepository();
            _userRepository = new UserRepository();
        }
    }
}