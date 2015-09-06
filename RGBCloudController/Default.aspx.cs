using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RGBCloudController
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            status.Text = string.Format("R: {0}, G: {1}, B: {2}", RGBData.R,RGBData.G,RGBData.B);
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            var n = ((Button)sender).Text;
            RGBData.Update(n);
        }
    }
}