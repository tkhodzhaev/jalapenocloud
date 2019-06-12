using JalapenoCloud.Bll.Services.Wrappers;
using JalapenoCloud.Common.Messaging.Responses;

namespace JalapenoCloud.Api
{
    public class AntispamService : IAntispamService
    {
        public PublicKeyResponse PublicKey()
        {
            PublicKeyResponse response = AntispamServiceWrapper.PublicKey();
            return response;
        }

        public IsSpammerResponse IsSpammer(string request)
        {
            IsSpammerResponse response = AntispamServiceWrapper.IsSpammer(request);
            return response;
        }

        public RegisterClientResponse RegisterClient(string request)
        {
            RegisterClientResponse response = AntispamServiceWrapper.RegisterClient(request);
            return response;
        }

        public RegisterClientResponse RegisterTestClient(string request)
        {
            RegisterClientResponse response = AntispamServiceWrapper.RegisterTestClient(request);
            return response;
        }

        public ComplainResponse Complain(string request)
        {
            ComplainResponse response = AntispamServiceWrapper.Complain(request);
            return response;
        }

        public NotifyAboutPaymentResponse NotifyAboutPayment(string request)
        {
            NotifyAboutPaymentResponse response = AntispamServiceWrapper.NotifyAboutPayment(request);
            return response;
        }
    }
}