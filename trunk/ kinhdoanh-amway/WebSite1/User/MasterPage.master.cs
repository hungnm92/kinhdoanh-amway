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
        if (Request.QueryString["MaADA"] == null)
        {
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        }
        if (Session["MaNPP"] == null)
           Response.Redirect("~/DangNhap.aspx");
        lblNPP.Text = "Xin chào " + Session["HoTenNPP"].ToString() + ".";
        lblMenu.Text = mn.LoadMenu(Session["MaNPP"].ToString(), 0);
    }
    protected void ChuyenTrang(object sender, EventArgs e)
    {
        Session["MaCD"] = 0;
        if(Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=0&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=0");
    }
    protected void ChuyenTrang1(object sender, EventArgs e)
    {
        Session["MaCD"] = 1;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=1&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=1");
    }
    protected void ChuyenTrang2(object sender, EventArgs e)
    {
        Session["MaCD"] = 2;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=2&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=2");
    }
    protected void ChuyenTrang3(object sender, EventArgs e)
    {
        Session["MaCD"] = 3;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=3&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=3");
    }
    protected void ChuyenTrang4(object sender, EventArgs e)
    {
        Session["MaCD"] = 4;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=4&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=4");
    }
    protected void ChuyenTrang5(object sender, EventArgs e)
    {
        Session["MaCD"] = 5;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=5&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=5");
    }
    protected void ChuyenTrang6(object sender, EventArgs e)
    {
        Session["MaCD"] = 6;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=6&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=6");
    }
    protected void ChuyenTrang7(object sender, EventArgs e)
    {
        Session["MaCD"] = 7;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=7&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=7");
    }
    protected void ChuyenTrang8(object sender, EventArgs e)
    {
        Session["MaCD"] = 8;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=8&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=8");
    }
    protected void KHChuyenTrang1(object sender, EventArgs e)
    {
        Session["Loai"] = false;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/KhachHang.aspx?Loai=0&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/KhachHang.aspx?Loai=0");
    }
    protected void KHChuyenTrang2(object sender, EventArgs e)
    {
        Session["Loai"] = true;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/KhachHang.aspx?Loai=1&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/KhachHang.aspx?Loai=1");
    }
    protected void SPChuyenTrang(object sender, EventArgs e)
    {
        Session["MaLSP"] = 1;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/SanPham.aspx?MaLSP=1&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/SanPham.aspx?MaLSP=1");
    }
    protected void SPChuyenTrang1(object sender, EventArgs e)
    {
        Session["MaLSP"] = 2;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/SanPham.aspx?MaLSP=2&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/SanPham.aspx?MaLSP=2");
    }
    protected void SPChuyenTrang2(object sender, EventArgs e)
    {
        Session["MaLSP"] = 3;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/SanPham.aspx?MaLSP=3&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/SanPham.aspx?MaLSP=3");
    }
    protected void SPChuyenTrang3(object sender, EventArgs e)
    {
        Session["MaLSP"] = 4;
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/SanPham.aspx?MaLSP=4&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/SanPham.aspx?MaLSP=4");
    }
    protected void SPChuyenTrang4(object sender, EventArgs e)
    {
        if (Session["MaKH"] == null)
        {
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/SanPham_GoiY.aspx?MaADA=" + Session["MaNPPClick"]);
            else
                Response.Redirect("~/User/SanPham_GoiY.aspx");
        }
        else
        {
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/SanPham_GoiY.aspx?MaKH=" + Session["MaKH"] + "&MaADA=" + Session["MaNPPClick"]);
            else
                Response.Redirect("~/User/SanPham_GoiY.aspx?MaKH=" + Session["MaKH"]);
        }
    }
    protected void SPChuyenTrang5(object sender, EventArgs e)
    {
        if (Session["MaKH"] == null)
        {
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/SanPham_DaDung.aspx?MaADA=" + Session["MaNPPClick"]);
            else
                Response.Redirect("~/User/SanPham_DaDung.aspx");
        }
        else
        {
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/SanPham_DaDung.aspx?MaKH=" + Session["MaKH"] + "&MaADA=" + Session["MaNPPClick"]);
            else
                Response.Redirect("~/User/SanPham_DaDung.aspx?MaKH=" + Session["MaKH"]);
        }
    }
    protected void find_Click(object sender, EventArgs e)
    {
        Session["HoTenNPPSearch"] = txtSearch.Text;
        Response.Redirect("~/User/TimNhaPhanPhoi.aspx?MaADA=" + Session["MaNPPClick"]);
    }
}
