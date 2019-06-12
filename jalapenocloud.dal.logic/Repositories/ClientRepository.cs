using System;
using System.Collections.Generic;
using System.Data;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Base;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Repositories
{
    public class ClientRepository : RepositoryBase<Client>
    {
        public ClientRepository()
            : base()
        {
        }

        public void BanClientsByUserId(Guid userId)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "UPDATE \"{0}\"".Parameters(Client.Table);
                sql += " SET \"IsDeleted\" = {0}".Params(true);
                sql += " WHERE (\"UserId\" = {0})".Params(userId);
                db.ExecuteSql(sql);
            }
        }

        public List<Client> FetchWithPaging(DateTime periodStart, DateTime periodEnd, string query, int limit, int offset)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT * FROM \"{0}\"".Parameters(Client.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);

                if (!string.IsNullOrWhiteSpace(query))
                    sql += " AND (\"UserId\" = {0})".Params(query);

                sql += " ORDER BY \"RegistrationDate\" DESC";
                sql += " LIMIT {0} OFFSET {1}".Params(limit, offset);
                List<Client> response = db.Query<Client>(sql);
                return response;
            }
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd, string query)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                string sql = "SELECT COUNT(*) FROM \"{0}\"".Parameters(Client.Table);
                sql += " WHERE (\"RegistrationDate\" BETWEEN {0} AND {1})".Params(periodStart, periodEnd);

                if (!string.IsNullOrWhiteSpace(query))
                    sql += " AND (\"UserId\" = {0})".Params(query);

                long response = db.Scalar<long>(sql);
                return response;
            }
        }
    }
}