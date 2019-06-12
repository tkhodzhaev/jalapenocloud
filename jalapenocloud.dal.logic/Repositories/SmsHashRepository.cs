using System;
using System.Collections.Generic;
using System.Data;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class SmsHashRepository : RepositoryBase<SmsHash>
    {
        public SmsHashRepository()
            : base()
        {
        }

        public List<SmsHash> FetchWithPaging(DateTime periodStart, DateTime periodEnd, int limit, int offset)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT * FROM \"{0}\"".Parameters(SmsHash.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);
                sql += " ORDER BY \"RegistrationDate\" DESC";
                sql += " LIMIT {0} OFFSET {1}".Params(limit, offset);
                List<SmsHash> response = db.Query<SmsHash>(sql);
                return response;
            }
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(SmsHash.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);
                long response = db.Scalar<long>(sql);
                return response;
            }
        }
    }
}