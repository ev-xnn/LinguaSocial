using System;

namespace YourProject
{
    public partial class ecommerce : System.Web.UI.MasterPage
    {
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string q = txtSearch.Text?.Trim();

            if (!string.IsNullOrWhiteSpace(q))
            {
                Response.Redirect("~/Products.aspx?q=" + Server.UrlEncode(q));
            }
        }
    }
}

