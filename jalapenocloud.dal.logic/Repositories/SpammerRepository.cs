using System;
using System.Collections.Generic;
using System.Data;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class SpammerRepository : RepositoryBase<Spammer>
    {
        public SpammerRepository()
            : base()
        {
        }

        public List<Spammer> FetchWithPaging(DateTime periodStart, DateTime periodEnd, string query, bool orderByTotalComplaints, int limit, int offset)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT * FROM \"{0}\"".Parameters(Spammer.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);

                if (!string.IsNullOrWhiteSpace(query))
                    sql += " AND (\"SenderId\" LIKE {0})".Params("%{0}%".Parameters(query));

                sql += orderByTotalComplaints ? " ORDER BY \"TotalComplaints\" DESC" : " ORDER BY \"RegistrationDate\" DESC";
                sql += " LIMIT {0} OFFSET {1}".Params(limit, offset);
                List<Spammer> response = db.Query<Spammer>(sql);
                return response;
            }
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd, string query)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(Spammer.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);

                if (!string.IsNullOrWhiteSpace(query))
                    sql += " AND (\"SenderId\" LIKE {0})".Params("%{0}%".Parameters(query));

                long response = db.Scalar<long>(sql);
                return response;
            }
        }
    }
}