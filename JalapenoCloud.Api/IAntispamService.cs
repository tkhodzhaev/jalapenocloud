using System.ServiceModel;
using System.ServiceModel.Web;
using JalapenoCloud.Common.Messaging.Responses;

namespace JalapenoCloud.Api
{
    [ServiceContract]
    public interface IAntispamService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "PublicKey", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        PublicKeyResponse PublicKey();

        [OperationContract]
        [WebInvoke(UriTemplate = "IsSpammer", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        IsSpammerResponse IsSpammer(string request);

        [OperationContract]
        [WebInvoke(UriTemplate = "RegisterClient", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        RegisterClientResponse RegisterClient(string request);

        [OperationContract]
        [WebInvoke(UriTemplate = "RegisterTestClient", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        RegisterClientResponse RegisterTestClient(string request);

        [OperationContract]
        [WebInvoke(UriTemplate = "Complain", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ComplainResponse Complain(string request);

        [OperationContract]
        [WebInvoke(UriTemplate = "NotifyAboutPayment", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        NotifyAboutPaymentResponse NotifyAboutPayment(string request);
    }
}