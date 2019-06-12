using System;

namespace UI.Controls
{
    public partial class Spinner : System.Web.UI.UserControl
    {
        private readonly int MIN = 1;
        private readonly int MAX = 500;

        public int Value
        {
            get
            {
                int value = 0;
                int.TryParse(tbxSpinner.Text, out value);

                if (value < MIN)
                    value = MIN;

                if (value > MAX)
                    value = MAX;

                tbxSpinner.Text = value.ToString();
                return value;
            }
            set
            {
                if (value < MIN)
                    value = MIN;

                if (value > MAX)
                    value = MAX;

                tbxSpinner.Text = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}