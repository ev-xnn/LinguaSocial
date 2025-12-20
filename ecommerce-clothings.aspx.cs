using System;
using System.Linq;
using System.Web.UI.WebControls;
using YourProject.Models;

namespace YourProject
{
    public partial class ecommerce_clothings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadClothings();
        }

        private void LoadClothings()
        {
            using (var db = new ApplicationDbContext())
            {
                var items = db.Products
                    .Where(p => p.Category == "Clothings")
                    .OrderByDescending(p => p.ProductId)
                    .ToList();

                if (items.Count == 0) lblMsg.Text = "No clothings found.";
                dlClothings.DataSource = items;
                dlClothings.DataBind();
            }
        }

        protected void dlClothings_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productId = int.Parse(e.CommandArgument.ToString());
                lblMsg.Text = "Added product ID " + productId + " to cart.";
            }
        }
    }
}
