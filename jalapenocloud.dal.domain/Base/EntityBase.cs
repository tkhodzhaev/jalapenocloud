using System;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Base
{
    public abstract class EntityBase
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}