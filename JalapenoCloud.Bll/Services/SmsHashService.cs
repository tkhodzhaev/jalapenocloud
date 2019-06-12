using System;
using System.Collections.Generic;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class SmsHashService : ServiceBase<SmsHash>
    {
        private SmsHashRepository _smsHashRepository;

        public SmsHashService()
            : base()
        {
            _smsHashRepository = new SmsHashRepository();
        }

        public List<SmsHash> FetchWithPaging(DateTime periodStart, DateTime periodEnd, int limit, int offset)
        {
            List<SmsHash> response = _smsHashRepository.FetchWithPaging(periodStart, periodEnd, limit, offset);
            return response;
        }

        public long TotalSmsHashes(DateTime periodStart, DateTime periodEnd)
        {
            long response = _smsHashRepository.GetTotalCount(periodStart, periodEnd);
            return response;
        }
    }
}