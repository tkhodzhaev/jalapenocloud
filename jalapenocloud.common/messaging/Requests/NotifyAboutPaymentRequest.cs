using System;

namespace JalapenoCloud.Common.Messaging.Requests
{
    public class NotifyAboutPaymentRequest
    {
        public Guid ClientId { get; set; }

        public string PaymentInfo { get; set; }
    }
}