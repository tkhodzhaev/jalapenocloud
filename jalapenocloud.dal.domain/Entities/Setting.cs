using System.ComponentModel.DataAnnotations;
using JalapenoCloud.Dal.Domain.Base;
using JalapenoCloud.Dal.Domain.Enums;
using ServiceStack.DataAnnotations;

namespace JalapenoCloud.Dal.Domain.Entities
{
    public class Setting : EntityBase
    {
        public static string Table { get { return typeof(Setting).Name; } }

        [Required]
        [Index(Unique = true)]
        public DbSettingKey Key { get; set; }

        [StringLength(2048)]
        public string Value { get; set; }

        public Setting()
            : base()
        {
        }
    }
}