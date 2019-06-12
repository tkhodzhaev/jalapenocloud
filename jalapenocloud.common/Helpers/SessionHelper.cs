using System.Web;
using ComfortFramework.Core.Helpers;

namespace JalapenoCloud.Common.Helpers
{
    public static class SessionHelper
    {
        public static T Get<T>(string key)
        {
            T response = ConvertHelper.ConvertTo<T>(HttpContext.Current.Session[key]);
            return response;
        }

        public static void Set(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}