using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Common.Enums;
using JalapenoCloud.Common.Helpers;

namespace JalapenoCloud.Common.Navigation
{
    public class Location
    {
        public class Param
        {
            public string Key { get; set; }

            public object Value { get; set; }

            public Param(string key, object value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

        public string Name { get; set; }

        public string Url { get; set; }

        public Location(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public string Parameterized(params Param[] parameters)
        {
            string response = Location.ParameterizedUrl(this.Url, parameters);
            return response;
        }

        public static string ParameterizedUrl(string url, params Param[] parameters)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            if (!url.EndsWith("?"))
                url += "?";

            if (parameters != null)
            {
                List<string> queryParameters = parameters.Select(c =>
                    "{0}={1}".Parameters(c.Key, c.Value)).ToList();

                url += string.Join("&", queryParameters);
            }

            return url;
        }

        public static string GetAbsoluteUrl(string relativeUrl)
        {
            HttpRequest request = HttpContext.Current.Request;
            string resolvedUrl = VirtualPathUtility.ToAbsolute(relativeUrl);
            string host = request.Url.Host;

            if (EnvironmentHelper.CurrentRunMode == ApplicationRunMode.Debug)
                host += ":" + request.Url.Port.ToString();

            string templateUrl = request.IsSecureConnection
                ? "https://{0}{1}" : "http://{0}{1}";

            string response = templateUrl.Parameters(host, resolvedUrl);
            return response;
        }
    }
}