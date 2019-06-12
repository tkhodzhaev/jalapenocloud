using System;
using System.Collections.Generic;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class UserService : ServiceBase<User>
    {
        private UserRepository _userRepository;
        private ClientRepository _clientRepository;

        public UserService()
            : base()
        {
            _userRepository = new UserRepository();
            _clientRepository = new ClientRepository();
        }

        public void BanUser(Guid id)
        {
            User user = _userRepository.GetById(id);
            user.IsDeleted = true;
            _userRepository.Save(user);

            _clientRepository.BanClientsByUserId(id);
        }

        public List<User> FetchWithPaging(DateTime periodStart, DateTime periodEnd, string query, int limit, int offset)
        {
            List<User> response = _userRepository.FetchWithPaging(periodStart, periodEnd, query, limit, offset);
            return response;
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd, string query)
        {
            long response = _userRepository.GetTotalCount(periodStart, periodEnd, query);
            return response;
        }
    }
}