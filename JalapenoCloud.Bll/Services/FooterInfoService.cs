using JalapenoCloud.Dal.Domain.Enums;

namespace JalapenoCloud.Bll.Services
{
    public static class FooterInfoService
    {
        public static string Credits()
        {
            string credits = new SettingService().GetDbSetting<string>(DbSettingKey.Credits);
            return credits;
        }
    }
}