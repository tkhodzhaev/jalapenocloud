using System.Web.UI.WebControls;
using ComfortFramework.Core.Helpers;

namespace UI.Controls
{
    public class PagingGrid : GridView
    {
        public PagingGrid()
            : base()
        {
        }

        public int TotalRows
        {
            get
            {
                object value = ViewState["TotalRows"];
                int response = ConvertHelper.ConvertTo<int>(value);
                return response;
            }
            set
            {
                ViewState["TotalRows"] = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                object value = ViewState["CurrentPageIndex"];
                int response = ConvertHelper.ConvertTo<int>(value);
                return response;
            }
            set
            {
                ViewState["CurrentPageIndex"] = value;
            }
        }

        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (pagedDataSource.IsPagingEnabled && (this.TotalRows != pagedDataSource.VirtualCount))
            {
                pagedDataSource.AllowCustomPaging = true;
                pagedDataSource.VirtualCount = this.TotalRows;
                pagedDataSource.CurrentPageIndex = this.CurrentPageIndex;
            }

            base.InitializePager(row, columnSpan, pagedDataSource);
        }

        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            this.CurrentPageIndex = e.NewPageIndex;
            this.SelectedIndex = -1;
        }
    }
}