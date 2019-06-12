namespace JalapenoCloud.Common.Messaging.Responses
{
    public class RegisterClientResponse : BasicResponse
    {
        public string ExpirationDate { get; set; }

        public bool UnlimitedAccess { get; set; }
    }
}