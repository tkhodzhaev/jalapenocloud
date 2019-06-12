using System.Collections;
using System.Collections.Generic;
using JalapenoCloud.Dal.Logic.Base;

namespace JalapenoCloud.Bll.Base
{
    public class ServiceBase<T> where T : new()
    {
        private RepositoryBase<T> _repository;

        public ServiceBase()
        {
            _repository = new RepositoryBase<T>();
        }

        public List<T> GetAll()
        {
            List<T> response = _repository.GetAll();
            return response;
        }

        public T GetById(object id)
        {
            T response = _repository.GetById(id);
            return response;
        }

        public List<T> GetByFilter(object filter)
        {
            List<T> response = _repository.GetByFilter(filter);
            return response;
        }

        public void Save(T entity)
        {
            _repository.Save(entity);
        }

        public void SaveMany(IEnumerable<T> entities)
        {
            _repository.SaveMany(entities);
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public void DeleteMany(IEnumerable ids)
        {
            _repository.DeleteMany(ids);
        }
    }
}