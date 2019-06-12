using System;
using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class ExceptionLog : EntityBase
    {
        public static string Table { get { return typeof(ExceptionLog).Name; } }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(2048)]
        public string MessageStack { get; set; }

        [Required]
        [StringLength(8192)]
        public string StackTrace { get; set; }

        public ExceptionLog()
            : base()
        {
        }
    }
}