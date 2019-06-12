using System;
using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class User : NotDeletableEntityBase
    {
        public static string Table { get { return typeof(User).Name; } }

        [Required]
        [Index(Unique = true)]
        [StringLength(128)]
        public string GoogleId { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Required]
        public bool UnlimitedAccess { get; set; }

        [Required]
        public bool Paid { get; set; }

        [StringLength(256)]
        public string PaymentInfo { get; set; }

        public DateTime? PaymentDate { get; set; }

        public User()
            : base()
        {
        }
    }
}