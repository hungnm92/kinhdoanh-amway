using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DoiMatKhau : System.Web.UI.Page
{
    lanhnt.NhaPhanPhoi npp = new lanhnt.NhaPhanPhoi();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btDoiMatKhau_Click(object sender, EventArgs e)
    {   
        bool bMatKhauCu = string.IsNullOrWhiteSpace(txtMatKhauCu.Text);
        bool bMatKhauMoi = string.IsNullOrWhiteSpace(txtMatKhauMoi.Text);
        bool bMatKhauXN = string.IsNullOrWhiteSpace(txtMatKhauXN.Text);
        if (bMatKhauCu == false && bMatKhauMoi == false & bMatKhauXN == false)
        {
            txtMaADA.Text = npp.MaADA;
            npp.MatKhauCu = txtMatKhauCu.Text;
            npp.MatKhauMoi = txtMatKhauMoi.Text;
            npp.MatKhauXN = txtMatKhauXN.Text;
            npp.DoiMatKhau();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập đầy đủ thông tin.";
        }
    }
}