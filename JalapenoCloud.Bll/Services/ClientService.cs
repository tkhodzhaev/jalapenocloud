using System;
using System.Collections.Generic;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class ClientService : ServiceBase<Client>
    {
        private ClientRepository _clientRepository;

        public ClientService()
            : base()
        {
            _clientRepository = new ClientRepository();
        }

        public List<Client> FetchWithPaging(DateTime periodStart, DateTime periodEnd, string query, int limit, int offset)
        {
            List<Client> response = _clientRepository.FetchWithPaging(periodStart, periodEnd, query, limit, offset);
            return response;
        }

        public long GetTotalCount(DateTime periodStart, DateTime periodEnd, string query)
        {
            long response = _clientRepository.GetTotalCount(periodStart, periodEnd, query);
            return response;
        }
    }
}