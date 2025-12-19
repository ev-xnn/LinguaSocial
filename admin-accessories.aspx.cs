using System;
using System.Linq;
using YourProject.Models;

namespace YourProject
{
    public partial class admin_accessories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional admin check (simple)
            // RequireAdmin();

            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            using (var db = new ApplicationDbContext())
            {
                var items = db.Products
                    .Where(p => p.Category == "Accessories")
                    .OrderByDescending(p => p.ProductId)
                    .ToList();

                gvAccessories.DataSource = items;
                gvAccessories.DataBind();
            }
        }

        protected void gvAccessories_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvAccessories.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvAccessories_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvAccessories.EditIndex = -1;
            BindGrid();
        }

        protected void gvAccessories_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = (int)gvAccessories.DataKeys[e.RowIndex].Value;
            var row = gvAccessories.Rows[e.RowIndex];

            string name = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string priceText = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text.Trim();

            var txtImagePath = (System.Web.UI.WebControls.TextBox)row.FindControl("txtImagePath");
            string imagePath = txtImagePath?.Text.Trim();

            if (!decimal.TryParse(priceText, out decimal price))
            {
                lblMsg.Text = "Invalid price.";
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                var p = db.Products.FirstOrDefault(x => x.ProductId == id);
                if (p == null) { lblMsg.Text = "Product not found."; return; }

                p.Name = name;
                p.Price = price;
                p.ImagePath = imagePath;
                p.Category = "Accessories"; // enforce category

                db.SaveChanges();
            }

            gvAccessories.EditIndex = -1;
            lblMsg.Text = "Updated.";
            BindGrid();
        }

        protected void gvAccessories_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = (int)gvAccessories.DataKeys[e.RowIndex].Value;

            using (var db = new ApplicationDbContext())
            {
                var p = db.Products.FirstOrDefault(x => x.ProductId == id);
                if (p == null) { lblMsg.Text = "Product not found."; return; }

                db.Products.Remove(p);
                db.SaveChanges();
            }

            lblMsg.Text = "Deleted.";
            BindGrid();
        }

        // Optional: basic session check
        private void RequireAdmin()
        {
            if (!(Session["IsAdmin"] is bool ok && ok))
                Response.Redirect("~/Login.aspx");
        }
    }
}
