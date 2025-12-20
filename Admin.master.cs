using System;

namespace YourProject
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: protect admin pages
            // if (!(Session["IsAdmin"] is bool ok && ok))
            //     Response.Redirect("~/Login.aspx");
        }
    }
}
