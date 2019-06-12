using System;
using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class SmsHash : NotDeletableEntityBase
    {
        public static string Table { get { return typeof(SmsHash).Name; } }

        [Required]
        [Index(Unique = true)]
        [StringLength(64)]
        public string Hash { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public long TotalComplaints { get; set; }

        public SmsHash()
            : base()
        {
        }
    }
}