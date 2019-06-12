using System;

namespace JalapenoCloud.Common.Messaging.Requests
{
    public class RegisterClientRequest
    {
        public Guid ClientId { get; set; }

        public string Token { get; set; }
    }
}