using System;

namespace JalapenoCloud.Common.Messaging.Requests
{
    public class IsSpammerRequest
    {
        public Guid ClientId { get; set; }

        public string SenderId { get; set; }

        public string Hash { get; set; }
    }
}