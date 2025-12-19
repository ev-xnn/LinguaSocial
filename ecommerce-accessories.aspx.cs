using YourProject.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace YourProject
{
    public partial class ecommerce_accessories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccessories();
            }
        }

        private void LoadAccessories()
        {
            using (var db = new ApplicationDbContext())
            {
                var items = db.Products
                    .Where(p => p.Category == "Accessories")
                    .OrderByDescending(p => p.ProductId)
                    .ToList();

                dlAccessories.DataSource = items;
                dlAccessories.DataBind();
            }
        }

        protected void dlAccessories_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productId = int.Parse(e.CommandArgument.ToString());

                // Placeholder for cart logic (Session-based later)
                lblMsg.Text = "Added product ID " + productId + " to cart.";
            }
        }
    }
}
