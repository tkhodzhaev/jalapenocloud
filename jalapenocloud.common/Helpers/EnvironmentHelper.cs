using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Common.Enums;

namespace JalapenoCloud.Common.Helpers
{
    public static class EnvironmentHelper
    {
        public static ApplicationRunMode CurrentRunMode
        {
            get
            {
#if DEBUG
                return ApplicationRunMode.Debug;
#else
                    return ApplicationRunMode.Release;
#endif
            }
        }

        public static Browser CurrentBrowser(HttpContext context)
        {
            HttpBrowserCapabilities browser = context.Request.Browser;
            Dictionary<Browser, string> browsers = EnumExtender.GetDictionary<Browser>(false);
            Browser response = browsers.Where(c => c.Value == browser.Browser).Select(c => c.Key).FirstOrDefault();
            return response;
        }
    }
}