using System.Linq;
using Newtonsoft.Json.Linq;

namespace JalapenoCloud.Common.Helpers
{
    public static class JsonHelper
    {
        public static string FindJProperty(string source, string propertyName)
        {
            JToken root = JToken.Parse(source);
            string response = RecursiveParsing(root, propertyName);
            return response;
        }

        private static string RecursiveParsing(JToken token, string propertyName)
        {
            if (token is JProperty)
            {
                var property = (JProperty)token;

                if (property.Name == propertyName)
                    return property.Value.ToString();
            }

            if (token.HasValues)
            {
                JToken[] tokens = token.Children().ToArray();

                for (int i = 0; i <= tokens.Count() - 1; i++)
                {
                    string response = RecursiveParsing(tokens[i], propertyName);

                    if (!string.IsNullOrEmpty(response))
                        return response;
                }
            }

            return null;
        }
    }
}