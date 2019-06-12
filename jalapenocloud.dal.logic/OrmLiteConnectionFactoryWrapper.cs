using System.Configuration;
using ComfortFramework.SystemNotification;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic
{
    public static class OrmLiteConnectionFactoryWrapper
    {
        private static OrmLiteConnectionFactory _factory = null;

        public static OrmLiteConnectionFactory Factory
        {
            get
            {
                if (_factory == null)
                    _factory = new OrmLiteConnectionFactory(GetConnectionString(), PostgreSqlDialect.Provider);

                return _factory;
            }
        }

        public static string GetConnectionString()
        {
            if (ConfigurationManager.ConnectionStrings["Default"] == null)
                throw new CFException("Connection string missing.");
            else
                return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}