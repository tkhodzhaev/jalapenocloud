using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using JalapenoCloud.Bll.Services;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Dal.Domain.Entities;
using UI.BaseClasses;

namespace UI
{
    public partial class Administrators : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CheckUserRights();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                Bind();
        }

        protected void gdvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                Guid id = Guid.Parse((string)e.CommandArgument);

                if (id == ConstantContainer.SuperadminId)
                {
                    umgOutput.AddStaticMessageToLine("You can't delete Him. Seriously, EVEN DON'T YOU TRY.", UI.Controls.UserMessage.MessageType.Error);
                    return;
                }

                var service = new AdminService();
                service.Delete(id);
                Bind();

                umgOutput.AddStaticMessageToLine("Done.", UI.Controls.UserMessage.MessageType.Success);
            }
        }

        private void Bind()
        {
            var service = new AdminService();
            List<Admin> response = service.GetAll();
            gdvData.DataSource = response;
            gdvData.DataBind();
        }
    }
}