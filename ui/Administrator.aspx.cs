using System;
using ComfortFramework.Core.Validation;
using JalapenoCloud.Bll.Services;
using JalapenoCloud.Common.Navigation;
using JalapenoCloud.Dal.Domain.Entities;
using UI.BaseClasses;

namespace UI
{
    public partial class Administrator : BasePage
    {
        private Admin Admin { get; set; }

        private bool SaveFormIsValid
        {
            get
            {
                bool isValid = true;

                if (!ManInfoValidator.ValidateEmail(tbxEmail.Text))
                {
                    isValid = false;
                    umgOutput.AddStaticMessageToLine("Invalid Email.", UI.Controls.UserMessage.MessageType.Error);
                }

                if (string.IsNullOrWhiteSpace(tbxName.Text))
                {
                    isValid = false;
                    umgOutput.AddStaticMessageToLine("Name empty.", UI.Controls.UserMessage.MessageType.Error);
                }

                if (phlPasswordSection.Visible)
                {
                    if (string.IsNullOrWhiteSpace(tbxPassword.Text))
                    {
                        isValid = false;
                        umgOutput.AddStaticMessageToLine("Password empty.", UI.Controls.UserMessage.MessageType.Error);
                    }

                    if (tbxPassword.Text != tbxPasswordConfirm.Text)
                    {
                        isValid = false;
                        umgOutput.AddStaticMessageToLine("Password and its confirmation don't match.", UI.Controls.UserMessage.MessageType.Error);
                    }
                }

                return isValid;
            }
        }

        private bool ChangePasswordFormIsValid
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrWhiteSpace(tbxEmail.Text))
                {
                    isValid = false;
                    umgOutput.AddStaticMessageToLine("Email empty.", UI.Controls.UserMessage.MessageType.Error);
                }

                if (string.IsNullOrWhiteSpace(tbxOldPassword.Text))
                {
                    isValid = false;
                    umgOutput.AddStaticMessageToLine("Old password empty.", UI.Controls.UserMessage.MessageType.Error);
                }

                if (string.IsNullOrWhiteSpace(tbxNewPassword.Text))
                {
                    isValid = false;
                    umgOutput.AddStaticMessageToLine("New password empty.", UI.Controls.UserMessage.MessageType.Error);
                }

                if (tbxNewPassword.Text != tbxNewPasswordConfirm.Text)
                {
                    isValid = false;
                    umgOutput.AddStaticMessageToLine("New password and its confirmation don't match.", UI.Controls.UserMessage.MessageType.Error);
                }

                return isValid;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CheckUserRights();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            umgOutput.HideStaticMessagesLine();
            BindAdmin();

            if (!this.IsPostBack)
                Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SaveFormIsValid)
                {
                    var service = new AdminService();
                    var admin = this.Admin;

                    if (admin == null && phlPasswordSection.Visible)
                        service.Add(tbxEmail.Text, tbxName.Text, tbxPassword.Text);

                    if (admin != null)
                    {
                        admin.Email = tbxEmail.Text;
                        admin.Name = tbxName.Text;
                        service.Save(admin);
                    }

                    Response.Redirect(Locations.Administrators.Url, true);
                }
            }
            catch (Exception ex)
            {
                umgOutput.AddStaticMessageToLine(ex.Message, UI.Controls.UserMessage.MessageType.Error);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ChangePasswordFormIsValid)
                {
                    var securityService = new SecurityService();
                    Admin admin = securityService.CheckCredentials(tbxEmail.Text, tbxOldPassword.Text);

                    if (admin == null)
                    {
                        umgOutput.AddStaticMessageToLine("Invalid login-password pair.", UI.Controls.UserMessage.MessageType.Error);
                    }
                    else
                    {
                        var adminService = new AdminService();
                        adminService.ChangePassword(admin.Id, tbxNewPassword.Text);

                        umgOutput.AddStaticMessageToLine("Done.", UI.Controls.UserMessage.MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                umgOutput.AddStaticMessageToLine(ex.Message, UI.Controls.UserMessage.MessageType.Error);
            }

            Bind();
        }

        private void BindAdmin()
        {
            try
            {
                string qid = GetParameter("id");

                if (string.IsNullOrWhiteSpace(qid))
                    return;

                Guid id = Guid.Parse(qid);
                var service = new AdminService();
                Admin admin = service.GetById(id);
                this.Admin = admin;

                if (admin == null)
                {
                    umgOutput.AddStaticMessageToLine("Admin not found.", UI.Controls.UserMessage.MessageType.Warning);
                    return;
                }
            }
            catch
            {
                umgOutput.AddStaticMessageToLine("Invalid query string parameter: id.", UI.Controls.UserMessage.MessageType.Warning);
            }
        }

        private void Bind()
        {
            if (this.Admin != null)
            {
                phlPasswordSection.Visible = false;
                phlChangePasswordSection.Visible = true;
                tbxEmail.Text = this.Admin.Email;
                tbxName.Text = this.Admin.Name;
            }
        }
    }
}