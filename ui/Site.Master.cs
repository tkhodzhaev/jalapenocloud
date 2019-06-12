using System;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Common.Navigation;
using JalapenoCloud.Common.Security;

namespace UI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public string UserLabel
        {
            get
            {
                return lblUser.Text;
            }
            set
            {
                lblUser.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            SetControls();
        }

        protected void btnInOut_Click(object sender, EventArgs e)
        {
            if (CurrentUserIdentity.IsAuthenticated)
                Logout();

            RedirectToLoginPage();
        }

        private void SetControls()
        {
            if (CurrentUserIdentity.IsAuthenticated)
            {
                btnInOut.Text = "Log Out";
                lblUser.Text = CurrentUserIdentity.Name;
            }
            else
            {
                btnInOut.Text = "Log In";
                lblUser.Text = null;
            }
        }

        private void Logout()
        {
            SessionHelper.Set(SessionKeys.CurrentUser, null);
            System.Web.Security.FormsAuthentication.SignOut();
        }

        private void RedirectToLoginPage()
        {
            Response.Redirect(Locations.Login.Url, true);
        }
    }
}