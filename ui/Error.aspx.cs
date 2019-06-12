using System;
using System.Security.Cryptography;
using System.Threading;
using UI.BaseClasses;

namespace UI
{
    public partial class Error : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (RandomNumberGenerator prng = new RNGCryptoServiceProvider())
            {
                byte[] delay = new byte[1];
                prng.GetBytes(delay);
                Thread.Sleep((int)delay[0]);
            }
        }
    }
}