using System.Collections;
using System.Collections.Generic;
using System.Data;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic.Base
{
    public class RepositoryBase<T> where T : new()
    {
        public RepositoryBase()
        {
        }

        public List<T> GetAll()
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                List<T> response = db.Select<T>();
                return response;
            }
        }

        public T GetById(object id)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                T response = db.GetByIdOrDefault<T>(id);
                return response;
            }
        }

        public List<T> GetByFilter(object filter)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                List<T> response = db.Where<T>(filter);
                return response;
            }
        }

        public void Save(T entity)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                db.Save(entity);
            }
        }

        public void SaveMany(IEnumerable<T> entities)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                db.SaveAll(entities);
            }
        }

        public void Delete(object id)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                db.DeleteById<T>(id);
            }
        }

        public void DeleteMany(IEnumerable ids)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                db.DeleteByIds<T>(ids);
            }
        }
    }
}