using System.Security.Principal;
using System.Web;

namespace JalapenoCloud.Common.Security
{
    public static class CurrentUserIdentity
    {
        public static bool IsAuthenticated
        {
            get
            {
                bool response = Identity == null ? false : Identity.IsAuthenticated;
                return response;
            }
        }

        public static string Name
        {
            get
            {
                string response = Identity == null ? null : Identity.Name;
                return response;
            }
        }

        public static IIdentity Identity
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.User == null)
                    return null;

                return HttpContext.Current.User.Identity;
            }
        }
    }
}