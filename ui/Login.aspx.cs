using System;
using System.Web.Security;
using JalapenoCloud.Bll.Services;
using JalapenoCloud.Common.Navigation;
using JalapenoCloud.Common.Security;
using JalapenoCloud.Dal.Domain.Entities;
using UI.BaseClasses;
using UI.Controls;

namespace UI
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUserIdentity.IsAuthenticated)
                Response.Redirect(Locations.Default.Url, true);

            if (!this.IsPostBack)
                tbxEmail.Focus();
            else
                tbxPassword.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var service = new SecurityService();
            Admin admin = service.CheckCredentials(tbxEmail.Text, tbxPassword.Text);

            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Name, chbRememberMe.Checked);
                Response.Redirect(Locations.Default.Url, true);
            }
            else
            {
                umgOutput.AddStaticMessageToLine("Invalid login-password pair.", UserMessage.MessageType.Error);
            }
        }
    }
}