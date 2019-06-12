using ComfortFramework.Core.Helpers;
using ComfortFramework.Core.Settings;
using JalapenoCloud.Common.Enums;

namespace JalapenoCloud.Common.Helpers
{
    public static class AppSettingHelper
    {
        public static T GetAppSetting<T>(string key)
        {
            string setting = SettingController.GetAppSetting(key);
            T response = ConvertHelper.ConvertTo<T>(setting);
            return response;
        }

        public static T GetAppSetting<T>(AppSettingKey key)
        {
            T response = GetAppSetting<T>(key.ToString());
            return response;
        }
    }
}