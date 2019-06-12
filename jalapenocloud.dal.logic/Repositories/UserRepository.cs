using System;
using System.Collections.Generic;
using System.Data;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository()
            : base()
        {
        }

        public List<User> FetchWithPaging(DateTime periodStart, DateTime periodEnd, string query, int limit, int offset)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT * FROM \"{0}\"".Parameters(User.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);

                if (!string.IsNullOrWhiteSpace(query))
                    sql += " AND (\"GoogleId\" LIKE '%{0}%' OR \"PaymentInfo\" LIKE '%{0}%' OR \"Email\" LIKE '%{0}%')".Parameters(query);

                sql += " ORDER BY \"RegistrationDate\" DESC";
                sql += " LIMIT {0} OFFSET {1}".Params(limit, offset);
                List<User> response = db.Query<User>(sql);
                return response;
            }
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd, string query, bool? paid = null)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(User.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);

                if (paid.HasValue)
                    sql += " AND (\"Paid\" = {0})".Params(paid.Value);

                if (!string.IsNullOrWhiteSpace(query))
                    sql += " AND (\"GoogleId\" LIKE '%{0}%' OR \"PaymentInfo\" LIKE '%{0}%' OR \"Email\" LIKE '%{0}%')".Parameters(query);

                long response = db.Scalar<long>(sql);
                return response;
            }
        }
    }
}