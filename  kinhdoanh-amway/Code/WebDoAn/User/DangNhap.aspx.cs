using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DangNhap : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        npp.MaNPP = txtMaNPP.Text;
        npp.MatKhau = txtMatKhau.Text;
        if ((string.IsNullOrWhiteSpace(txtMatKhau.Text) == false) && (string.IsNullOrWhiteSpace(txtMaNPP.Text) == false))
        {
            if (npp.DangNhap() == true)
            {
                Session["MaNPP"] = npp.MaNPP;
                Session["HoTenNPP"] = npp.HoNPP + " " + npp.TenNPP;
                Response.Redirect("~/User/TrangChu.aspx");
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
            }
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập mã ADA hoặc mật khẩu.";
        }
    }
}