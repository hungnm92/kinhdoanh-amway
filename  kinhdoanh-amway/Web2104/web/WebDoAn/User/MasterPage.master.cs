using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterPage : System.Web.UI.MasterPage
{
    webdoan.Menu mn = new webdoan.Menu();
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["MaNPP"] == null)
           Response.Redirect("~/DangNhap.aspx");
        lblNPP.Text = "Xin chào " + Session["HoTenNPP"].ToString() + ".";
        lblMenu.Text = mn.LoadMenu(Session["MaNPP"].ToString(), 0);
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
    protected void ChuyenTrang2(object sender, EventArgs e)
    {
        Session["MaCD"] = 2;
        Response.Redirect("~/User/NhaPhanPhoi.aspx");
    }
    protected void ChuyenTrang3(object sender, EventArgs e)
    {
        Session["MaCD"] = 3;
        Response.Redirect("~/User/NhaPhanPhoi.aspx");
    }
    protected void KHChuyenTrang1(object sender, EventArgs e)
    {
        Session["Loai"] = false;
        Response.Redirect("~/User/KhachHang.aspx");
    }
    protected void KHChuyenTrang2(object sender, EventArgs e)
    {
        Session["Loai"] = true;
        Response.Redirect("~/User/KhachHang.aspx");
    }
    protected void SPChuyenTrang(object sender, EventArgs e)
    {
        Session["MaLMH"] = 1;
        Response.Redirect("~/User/SanPham.aspx");
    }
    protected void SPChuyenTrang1(object sender, EventArgs e)
    {
        Session["MaLMH"] = 2;
        Response.Redirect("~/User/SanPham.aspx");
    }
    protected void SPChuyenTrang2(object sender, EventArgs e)
    {
        Session["MaLMH"] = 3;
        Response.Redirect("~/User/SanPham.aspx");
    }
    protected void SPChuyenTrang3(object sender, EventArgs e)
    {
        Session["MaLMH"] = 4;
        Response.Redirect("~/User/SanPham.aspx");
    }
}
