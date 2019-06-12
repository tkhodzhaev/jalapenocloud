using ComfortFramework.Core.Helpers;
using JalapenoCloud.Common.Navigation;
using JalapenoCloud.Common.Security;

namespace UI.BaseClasses
{
    public abstract class BasePage : System.Web.UI.Page
    {
        protected string GetParameter(string key)
        {
            string value = this.Request.QueryString[key];
            return value;
        }

        protected T GetParameter<T>(string key)
        {
            string value = this.Request.QueryString[key];
            T response = ConvertHelper.ConvertTo<T>(value);
            return response;
        }

        protected T GetFromViewState<T>(string key)
        {
            object value = ViewState[key];
            T response = ConvertHelper.ConvertTo<T>(value);
            return response;
        }

        protected void NavigateToControl(System.Web.UI.Control control)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate",
                "document.getElementById('" + control.ClientID + "').scrollIntoView();",
                true);
        }

        protected void CheckUserRights()
        {
            AuthenticateUser();
        }

        protected void AuthenticateUser()
        {
            if (!CurrentUserIdentity.IsAuthenticated)
            {
                string redirectUrl = Locations.Login.Url;
                Response.Redirect(redirectUrl, true);
            }
        }
    }
}