using System;
using UI.BaseClasses;

namespace UI
{
    public partial class Default : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CheckUserRights();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}