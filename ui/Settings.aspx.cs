using System;
using System.Collections.Generic;
using System.Linq;
using ComfortFramework.Core.Extenders;
using ComfortFramework.Core.Helpers;
using JalapenoCloud.Bll.Services;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Domain.Enums;
using UI.BaseClasses;

namespace UI
{
    public partial class Settings : BasePage
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

        protected void gdvData_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gdvData.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void gdvData_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gdvData.EditIndex = -1;
            Bind();
        }

        protected void gdvData_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            var setting = new Setting();
            setting.Id = new Guid(gdvData.Rows[e.RowIndex].Cells[1].Text);
            setting.Key = EnumExtender.FromString<DbSettingKey>(ConvertHelper.ConvertTo<string>(gdvData.Rows[e.RowIndex].Cells[2].Text));
            setting.Value = ConvertHelper.ConvertTo<string>(e.NewValues["Value"]);

            var service = new SettingService();
            service.Save(setting);

            gdvData.EditIndex = -1;
            Bind();
        }

        protected void gdvData_RowUpdated(object sender, System.Web.UI.WebControls.GridViewUpdatedEventArgs e)
        {
        }

        protected void btnGenerateNewKeyPair_Click(object sender, EventArgs e)
        {
            CryptoService.GenerateNewKeyPair();
            umgOutput.AddStaticMessageToLine("Done.", UI.Controls.UserMessage.MessageType.Success);
            Bind();
        }

        private void Bind()
        {
            var service = new SettingService();
            List<Setting> response = service.GetAll().Where(c => c.Key != DbSettingKey.PrivateKey).OrderBy(c => c.Key).ToList();
            gdvData.DataSource = response;
            gdvData.DataBind();
        }
    }
}