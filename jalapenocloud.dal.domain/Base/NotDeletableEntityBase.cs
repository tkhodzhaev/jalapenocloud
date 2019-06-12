using System.ComponentModel.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Base
{
    public abstract class NotDeletableEntityBase : EntityBase
    {
        [Required]
        public bool IsDeleted { get; set; }

        public NotDeletableEntityBase()
            : base()
        {
        }
    }
}