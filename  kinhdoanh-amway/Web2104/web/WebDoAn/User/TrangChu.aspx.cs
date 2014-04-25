using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Default : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.CapDo cd = new webdoan.CapDo();
    webdoan.Duong dll = new webdoan.Duong();
    webdoan.Duong dtt = new webdoan.Duong();
    webdoan.XaPhuong xpll = new webdoan.XaPhuong();
    webdoan.XaPhuong xptt = new webdoan.XaPhuong();
    webdoan.Huyen hll = new webdoan.Huyen();
    webdoan.Huyen htt = new webdoan.Huyen();
    webdoan.Tinh tll = new webdoan.Tinh();
    webdoan.Tinh ttt = new webdoan.Tinh();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            droCapDo.DataSource = cd.DS();
            droCapDo.DataBind();
            droDuongNPPLL.DataSource = dll.DS();
            droDuongNPPLL.DataBind();
            droDuongNPPTT.DataSource = dtt.DS();
            droDuongNPPTT.DataBind();
            droXaNPPLL.DataSource = xpll.DS();
            droXaNPPLL.DataBind();
            droXaNPPTT.DataSource = xptt.DS();
            droXaNPPTT.DataBind();
            droHuyenNPPLL.DataSource = hll.DS();
            droHuyenNPPLL.DataBind();
            droHuyenNPPTT.DataSource = htt.DS();
            droHuyenNPPTT.DataBind();
            droTinhNPPLL.DataSource = tll.DS();
            droTinhNPPLL.DataBind();
            droTinhNPPTT.DataSource = ttt.DS();
            droTinhNPPTT.DataBind();
            droNBT.DataSource = npp.DS();
            droNBT.DataBind();
            if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
            {
                npp.MaNPP = Session["MaNPP"].ToString();
            }
            else
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.CT();
            txtMaNPP.Text = npp.MaNPP;
            txtHoNPP.Text = npp.HoNPP;
            txtTenNPP.Text = npp.TenNPP;
            txtNgaySinh.Text = npp.NgaySinh;
            if (npp.GioiTinh == true)
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;
            imgAnhNPP.ImageUrl = "~/src/emp/" + npp.AnhNPP;
            txtCMND.Text = npp.CMND;
            txtSoDT.Text = npp.SoDT;
            txtEmail.Text = npp.Email;
            txtNgayKyThe.Text = npp.NgayKyThe;
            txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
            txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
            npp.MaNPP = npp.MaNBT;
            droNBT.SelectedValue = npp.MaNPP.ToString();
            cd.MaCD = npp.MaCD;
            droCapDo.SelectedValue = cd.MaCD.ToString();
            dll.MaDuong = npp.MaDuongNPPLL;
            droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
            dtt.MaDuong = npp.MaDuongNPPTT;
            droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
            xpll.MaXa = npp.MaXaNPPLL;
            droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
            xptt.MaXa = npp.MaXaNPPTT;
            droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
            hll.MaHuyen = npp.MaHuyenNPPLL;
            droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
            htt.MaHuyen = npp.MaHuyenNPPTT;
            droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
            tll.MaTinh = npp.MaTinhNPPLL;
            droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
            ttt.MaTinh = npp.MaTinhNPPTT;
            droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
        }
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            //npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            if(rdoNam.Checked == true)
                npp.GioiTinh = true;
            else
                npp.GioiTinh = false;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/emp/");
            DuongDan = DuongDan + fileAnhNPP.FileName;
            fileAnhNPP.SaveAs(DuongDan);
            npp.AnhNPP = fileAnhNPP.FileName;
            npp.CMND = txtCMND.Text;
            npp.SoDT = txtSoDT.Text;
            npp.Email = txtEmail.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
            npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
            npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
            npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
            npp.MaCD = int.Parse(droCapDo.SelectedValue);
            npp.MaNBT = droNBT.SelectedValue;
            npp.Sua();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
        }
        else
            if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == false)
            {
                npp.MaNPP = Session["MaNPP"].ToString();
               // npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                string temp = npp.AnhNPP.ToString();
                npp.HoNPP = txtHoNPP.Text;
                npp.TenNPP = txtTenNPP.Text;
                npp.NgaySinh = txtNgaySinh.Text;
                if (rdoNam.Checked == true)
                    npp.GioiTinh = true;
                else
                    npp.GioiTinh = false;
                npp.AnhNPP = temp;
                npp.CMND = txtCMND.Text;
                npp.SoDT = txtSoDT.Text;
                npp.Email = txtEmail.Text;
                npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
                npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
                npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
                npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
                npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
                npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
                npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
                npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
                npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
                npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
                npp.MaCD = int.Parse(droCapDo.SelectedValue);
                npp.MaNBT = droNBT.SelectedValue;
                npp.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Các vị trí * bắt buộc bạn phải nhập.";
            }
    }
}