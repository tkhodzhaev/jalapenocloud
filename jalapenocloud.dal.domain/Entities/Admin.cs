using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class Admin : EntityBase
    {
        public static string Table { get { return typeof(Admin).Name; } }

        private string _email;

        [Required]
        [Index(Unique = true)]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [Index(Unique = true)]
        [StringLength(128)]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    value = value.ToLower();

                _email = value;
            }
        }

        [Required]
        [StringLength(28)]
        public string Password { get; set; }

        [Required]
        [StringLength(24)]
        public string PasswordSalt { get; set; }

        public Admin()
            : base()
        {
        }
    }
}