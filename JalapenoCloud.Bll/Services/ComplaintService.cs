using System;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class ComplaintService : ServiceBase<Complaint>
    {
        private ComplaintRepository _complaintRepository;

        public ComplaintService()
            : base()
        {
            _complaintRepository = new ComplaintRepository();
        }

        public long GetUserComplaintsCount(Guid userId, DateTime periodStart, DateTime periodEnd)
        {
            long response = _complaintRepository.GetUserComplaintsCount(userId, periodStart, periodEnd);
            return response;
        }
    }
}