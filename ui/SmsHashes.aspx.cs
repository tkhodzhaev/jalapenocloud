using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Bll.Services;
using JalapenoCloud.Dal.Domain.Entities;
using UI.BaseClasses;
using UI.Controls;

namespace UI
{
    public partial class SmsHashes : BasePage
    {
        private readonly string _vskPageSize = "PageSize";

        private int PageSize
        {
            get
            {
                return tspPageSize.Value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CheckUserRights();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pgdData.PageSize = PageSize;

            if (!this.IsPostBack)
                Bind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Bind();
        }

        protected void pgdData_PageIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }

        protected void pgdData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ban")
            {
                Guid id = Guid.Parse((string)e.CommandArgument);

                var service = new SmsHashService();
                SmsHash smsHash = service.GetById(id);
                smsHash.IsDeleted = true;
                service.Save(smsHash);

                Bind();
            }
        }

        private void Bind()
        {
            var smsHashService = new SmsHashService();

            long countResponse = smsHashService.TotalSmsHashes(tpdRange.Start, tpdRange.End);
            pgdData.TotalRows = (int)countResponse;
            pgdData.CurrentPageIndex = CalculatePageIndex(pgdData);
            pgdData.PageIndex = pgdData.CurrentPageIndex;

            List<SmsHash> fetchResponse = smsHashService.FetchWithPaging(tpdRange.Start, tpdRange.End, pgdData.PageSize, pgdData.CurrentPageIndex * pgdData.PageSize);
            pgdData.DataSource = fetchResponse;
            pgdData.DataBind();

            lblGridHeader.Text = "SMS Hashes" + (pgdData.TotalRows > 0 ? " ({0})".Parameters(pgdData.TotalRows.ToString()) : string.Empty);

            ViewState[_vskPageSize] = PageSize;
        }

        private int CalculatePageIndex(PagingGrid grid)
        {
            int offset = grid.CurrentPageIndex * grid.PageSize;
            int index = (grid.TotalRows > offset && grid.PageSize == GetFromViewState<int>(_vskPageSize)) ? grid.CurrentPageIndex : 0;
            return index;
        }
    }
}