using System;
using System.IO;
using System.Linq;
using YourProject.Models;

namespace YourProject
{
    public partial class admin_accessories_manage : System.Web.UI.Page
    {
        private int? ProductId
        {
            get
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                    return id;
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional admin check
            // RequireAdmin();

            if (!IsPostBack)
            {
                if (ProductId.HasValue)
                    LoadProduct(ProductId.Value);
            }
        }

        private void LoadProduct(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var p = db.Products.FirstOrDefault(x => x.ProductId == id && x.Category == "Accessories");
                if (p == null) { lblMsg.Text = "Accessory not found."; return; }

                txtName.Text = p.Name;
                txtPrice.Text = p.Price.ToString("0.00");
                txtImagePath.Text = p.ImagePath;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                lblMsg.Text = "Name is required.";
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                lblMsg.Text = "Invalid price.";
                return;
            }

            string finalImagePath = txtImagePath.Text.Trim();

            // Handle image upload if provided
            if (fuImage.HasFile)
            {
                string folder = Server.MapPath("~/Images/Products/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string ext = Path.GetExtension(fuImage.FileName).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                {
                    lblMsg.Text = "Only .jpg, .jpeg, .png allowed.";
                    return;
                }

                string fileName = Guid.NewGuid().ToString("N") + ext;
                string fullPath = Path.Combine(folder, fileName);
                fuImage.SaveAs(fullPath);

                finalImagePath = "Images/Products/" + fileName; // store relative path
            }

            using (var db = new ApplicationDbContext())
            {
                Product p;

                if (ProductId.HasValue)
                {
                    p = db.Products.FirstOrDefault(x => x.ProductId == ProductId.Value);
                    if (p == null) { lblMsg.Text = "Product not found."; return; }
                }
                else
                {
                    p = new Product();
                    db.Products.Add(p);
                }

                p.Name = name;
                p.Price = price;
                p.ImagePath = finalImagePath;
                p.Category = "Accessories"; // enforce

                db.SaveChanges();
            }

            Response.Redirect("~/admin-accessories.aspx");
        }

        // Optional: basic session check
        private void RequireAdmin()
        {
            if (!(Session["IsAdmin"] is bool ok && ok))
                Response.Redirect("~/Login.aspx");
        }
    }
}
