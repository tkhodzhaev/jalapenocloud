using System;
using System.Collections.Generic;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class SpammerService : ServiceBase<Spammer>
    {
        private SpammerRepository _spammerRepository;

        public SpammerService()
            : base()
        {
            _spammerRepository = new SpammerRepository();
        }

        public List<Spammer> FetchWithPaging(DateTime periodStart, DateTime periodEnd, string query, bool orderByTotalComplaints, int limit, int offset)
        {
            List<Spammer> response = _spammerRepository.FetchWithPaging(periodStart, periodEnd, query, orderByTotalComplaints, limit, offset);
            return response;
        }

        public long TotalSpammers(DateTime periodStart, DateTime periodEnd, string query)
        {
            long response = _spammerRepository.GetTotalCount(periodStart, periodEnd, query);
            return response;
        }
    }
}