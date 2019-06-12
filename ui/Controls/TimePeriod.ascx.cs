using System;

namespace UI.Controls
{
    public partial class TimePeriod : System.Web.UI.UserControl
    {
        public DateTime Start
        {
            get
            {
                DateTime response;
                return DateTime.TryParse(tbxStart.Text, out response) ? response : DateTime.MinValue;
            }
            set
            {
                tbxStart.Text = value.ToString("dd.MM.yyyy");
            }
        }

        public DateTime End
        {
            get
            {
                DateTime response;
                return DateTime.TryParse(tbxEnd.Text, out response) ? response.AddDays(1) : DateTime.MaxValue;
            }
            set
            {
                tbxEnd.Text = value.ToString("dd.MM.yyyy");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}