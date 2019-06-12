using System;
using System.Collections.Generic;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class ExceptionLogService : ServiceBase<ExceptionLog>
    {
        private ExceptionLogRepository _exceptionLogRepository;

        public ExceptionLogService()
            : base()
        {
            _exceptionLogRepository = new ExceptionLogRepository();
        }

        public List<ExceptionLog> FetchWithPaging(DateTime periodStart, DateTime periodEnd, int limit, int offset)
        {
            List<ExceptionLog> response = _exceptionLogRepository.FetchWithPaging(periodStart, periodEnd, limit, offset);
            return response;
        }

        public void RegisterException(Exception ex)
        {
            try
            {
                var exceptionLog = new ExceptionLog();
                exceptionLog.Date = DateTime.UtcNow;
                exceptionLog.MessageStack = ExceptionHelper.GetExceptionMessages(ex);
                exceptionLog.StackTrace = ex.StackTrace;

                this.Save(exceptionLog);
            }
            catch
            {
            }
        }
    }
}