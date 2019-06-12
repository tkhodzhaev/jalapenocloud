using System.Data;
using System.Linq;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Domain.Enums;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class SettingRepository : RepositoryBase<Setting>
    {
        public SettingRepository()
            : base()
        {
        }

        public Setting GetByKey(DbSettingKey key)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                Setting response = db.Select<Setting>(ev => ev.Where(c => c.Key == key)).FirstOrDefault();
                return response;
            }
        }
    }
}