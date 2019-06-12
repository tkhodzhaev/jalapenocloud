using System;
using System.Collections.Generic;
using System.Data;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class ExceptionLogRepository : RepositoryBase<ExceptionLog>
    {
        public ExceptionLogRepository()
            : base()
        {
        }

        public List<ExceptionLog> FetchWithPaging(DateTime periodStart, DateTime periodEnd, int limit, int offset)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT * FROM \"{0}\"".Parameters(ExceptionLog.Table);
                sql += " WHERE (\"Date\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);
                sql += " ORDER BY \"Date\" DESC";
                sql += " LIMIT {0} OFFSET {1}".Params(limit, offset);
                List<ExceptionLog> response = db.Query<ExceptionLog>(sql);
                return response;
            }
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(ExceptionLog.Table);
                sql += " WHERE (\"Date\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);
                long response = db.Scalar<long>(sql);
                return response;
            }
        }
    }
}