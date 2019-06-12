using System;
using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class Client : NotDeletableEntityBase
    {
        public static string Table { get { return typeof(Client).Name; } }

        [Required]
        [References(typeof(User))]
        public Guid UserId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public Client()
            : base()
        {
        }

        public Client(Guid id)
        {
            this.Id = id;
        }
    }
}