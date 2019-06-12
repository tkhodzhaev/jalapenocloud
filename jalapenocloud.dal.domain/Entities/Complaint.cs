using System;
using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class Complaint : EntityBase
    {
        public static string Table { get { return typeof(Complaint).Name; } }

        [Required]
        [References(typeof(User))]
        public Guid UserId { get; set; }

        [Required]
        [References(typeof(Spammer))]
        public Guid SpammerId { get; set; }

        [Required]
        [StringLength(64)]
        public string SmsHash { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Complaint()
            : base()
        {
        }
    }
}