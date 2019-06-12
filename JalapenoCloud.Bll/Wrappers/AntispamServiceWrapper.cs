using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using ComfortFramework.Core.Extenders;
using ComfortFramework.Core.Helpers;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Common.Messaging.Requests;
using JalapenoCloud.Common.Messaging.Responses;
using JalapenoCloud.Dal.Domain.Enums;

namespace JalapenoCloud.Bll.Services.Wrappers
{
    public static class AntispamServiceWrapper
    {
        public static PublicKeyResponse PublicKey()
        {
            
            Guid requestId = Guid.NewGuid();

            try
            {
                bool allRequestsLoggingMode = new SettingService().GetDbSetting<bool>(DbSettingKey.AllRequestsLoggingMode);

                if (allRequestsLoggingMode)
                    NotificationAndLogService.LogRequest("PublicKey()", requestId, "PublicKey");

                var service = new AntispamService();
                PublicKeyResponse objResponse = service.PublicKey();

                return objResponse;
            }
            catch (Exception ex)
            {
                return ProceedException<PublicKeyResponse>(ex, requestId, "PublicKey");
            }
        }

        public static IsSpammerResponse IsSpammer(string request)
        {
            Guid requestId = Guid.NewGuid();

            const string requestName = "IsSpammer";
            try
            {
                var objRequest = ReadRequest<IsSpammerRequest>(request, requestId, requestName);
                var service = new AntispamService();
                IsSpammerResponse objResponse = service.IsSpammer(objRequest);
                LogResponse(objResponse, requestId, requestName);

                return objResponse;
            }
            catch (Exception ex)
            {
                return ProceedException<IsSpammerResponse>(ex, requestId, requestName);
            }
        }

        public static RegisterClientResponse RegisterClient(string request)
        {
            Guid requestId = Guid.NewGuid();

            const string requestName = "RegisterClient";
            try
            {
                var objRequest = ReadRequest<RegisterClientRequest>(request, requestId, requestName);
                var service = new AntispamService();
                RegisterClientResponse objResponse = service.RegisterClient(objRequest);
                LogResponse(objResponse, requestId, requestName);

                return objResponse;
            }
            catch (Exception ex)
            {
                return ProceedException<RegisterClientResponse>(ex, requestId, requestName);
            }
        }

        public static RegisterClientResponse RegisterTestClient(string request)
        {
            Guid requestId = Guid.NewGuid();

            string requestName = "RegisterTestClient";
            try
            {
                var objRequest = ReadRequest<RegisterClientRequest>(request, requestId, requestName);
                var service = new AntispamService();
                RegisterClientResponse objResponse = service.RegisterTestClient(objRequest);
                LogResponse(objResponse, requestId, requestName);

                return objResponse;
            }
            catch (Exception ex)
            {
                return ProceedException<RegisterClientResponse>(ex, requestId, requestName);
            }
        }

        public static ComplainResponse Complain(string request)
        {
            Guid requestId = Guid.NewGuid();

            string requestName = "Complain";
            try
            {
                var objRequest = ReadRequest<ComplainRequest>(request, requestId, requestName);
                var service = new AntispamService();
                ComplainResponse objResponse = service.Complain(objRequest);
                LogResponse(objResponse, requestId, requestName);

                return objResponse;
            }
            catch (Exception ex)
            {
                return ProceedException<ComplainResponse>(ex, requestId, requestName);
            }
        }

        public static NotifyAboutPaymentResponse NotifyAboutPayment(string request)
        {
            Guid requestId = Guid.NewGuid();

            string requestName = "NotifyAboutPayment";
            try
            {
                var objRequest = ReadRequest<NotifyAboutPaymentRequest>(request, requestId, requestName);
                var service = new AntispamService();
                NotifyAboutPaymentResponse objResponse = service.NotifyAboutPayment(objRequest);
                LogResponse(objResponse, requestId, requestName);

                return objResponse;
            }
            catch (Exception ex)
            {
                return ProceedException<NotifyAboutPaymentResponse>(ex, requestId, requestName);
            }
        }

        private static T ReadRequest<T>(string request, Guid requestId, string requestName)
        {
            bool allRequestsLoggingMode = new SettingService().GetDbSetting<bool>(DbSettingKey.AllRequestsLoggingMode);

            if (allRequestsLoggingMode)
                NotificationAndLogService.LogRequest(request, requestId, requestName);

            string decodedRequest = DecodeRequest(request);

            if (allRequestsLoggingMode)
                NotificationAndLogService.LogRequest(decodedRequest, requestId, requestName);

            var objRequest = SerializationHelper.DeserializeFromJson<T>(decodedRequest);
            return objRequest;
        }

        private static void LogResponse<T>(T response, Guid requestId, string requestName) where T : BasicResponse
        {
            bool allRequestsLoggingMode = new SettingService().GetDbSetting<bool>(DbSettingKey.AllRequestsLoggingMode);

            if (allRequestsLoggingMode)
            {
                string jsonResponse = response.SerializeToJson();
                NotificationAndLogService.LogResponse(jsonResponse, requestId, requestName, response.WasSuccessful);
            }
        }

        private static T ProceedException<T>(Exception ex, Guid requestId, string requestName) where T : BasicResponse, new()
        {
            NotificationAndLogService.LogException(ex, requestId, requestName);
            new ExceptionLogService().RegisterException(ex);

            var response = new T
            {
                WasSuccessful = false
            };

            if (ex is CryptographicException)
            {
                response.ErrorMessage = ServerErrors.InvalidPublicKey;
            }
            else
            {
                response.ErrorMessage = ServerErrors.InvalidRequest;
            }

            return response;
        }

        private static string DecodeRequest(string request)
        {
            var settingService = new SettingService();
            bool requestEncodingEnabled = settingService.GetDbSetting<bool>(DbSettingKey.RequestEncodingEnabled);

            if (requestEncodingEnabled)
            {
                byte[] encryptedData = Convert.FromBase64String(request);
                byte[] decryptedData = CryptoService.Decode(encryptedData);
                string decodedRequest = StringHelper.GetString(decryptedData);
                return decodedRequest;
            }
            else
            {
                string decodedRequest = StringHelper.GetString(Convert.FromBase64String(request));
                return decodedRequest;
            }
        }
    }
}