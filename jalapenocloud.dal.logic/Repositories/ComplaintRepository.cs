using System;
using System.Data;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class ComplaintRepository : RepositoryBase<Complaint>
    {
        public ComplaintRepository()
            : base()
        {
        }

        public long GetUserComplaintsCount(Guid userId, DateTime periodStart, DateTime periodEnd)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(Complaint.Table);
                sql += " WHERE (\"UserId\" = {0})".Params(userId);
                sql += " AND (\"Date\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);
                long response = db.Scalar<long>(sql);
                return response;
            }
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(Complaint.Table);
                sql += " WHERE (\"Date\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);
                long response = db.Scalar<long>(sql);
                return response;
            }
        }
    }
}