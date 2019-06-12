using System;
using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class Spammer : NotDeletableEntityBase
    {
        public static string Table { get { return typeof(Spammer).Name; } }

        [Required]
        [Index(Unique = true)]
        [StringLength(32)]
        public string SenderId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public long TotalComplaints { get; set; }

        public Spammer()
            : base()
        {
        }
    }
}