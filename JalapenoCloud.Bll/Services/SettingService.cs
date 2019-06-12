using ComfortFramework.Core.Helpers;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Domain.Enums;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class SettingService : ServiceBase<Setting>
    {
        private SettingRepository _settingRepository;

        public SettingService()
            : base()
        {
            _settingRepository = new SettingRepository();
        }

        public Setting GetByKey(DbSettingKey key)
        {
            Setting response = _settingRepository.GetByKey(key);
            return response;
        }

        public T GetDbSetting<T>(DbSettingKey key)
        {
            Setting response = _settingRepository.GetByKey(key);

            if (response == null)
                return default(T);
            else
                return ConvertHelper.ConvertTo<T>(response.Value);
        }
    }
}