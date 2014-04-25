using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaNPP"] == null)
            Response.Redirect("~/User/DangNhap.aspx");
        webdoan.Menu mn = new webdoan.Menu();
        lblMenu.Text = mn.LoadMenu(Session["MaNPP"].ToString(), 0);
        lblNPP.Text = "Xin chào " + Session["HoTenNPP"].ToString() + ".";
    }

    protected void ChuyenTrang(object sender, EventArgs e)
    {
        Session["MaCD"] = 0;
        Response.Redirect("~/User/NhaPhanPhoi.aspx");
    }
    protected void ChuyenTrang1(object sender, EventArgs e)
    {
        Session["MaCD"] = 1;
        Response.Redirect("~/User/NhaPhanPhoi.aspx");
    }
}
