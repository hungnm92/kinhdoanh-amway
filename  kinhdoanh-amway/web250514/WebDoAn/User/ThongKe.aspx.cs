using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class User_NhaPhanPhoi : System.Web.UI.Page
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
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.DaoTao dt = new webdoan.DaoTao();
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    webdoan.DoanhThu dthu = new webdoan.DoanhThu();
    webdoan.QuaTrinhCD qtcd = new webdoan.QuaTrinhCD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["MaCD"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            //cd.MaCD = int.Parse(Session["MaCD"].ToString());
            droCapDo.DataSource = cd.DS();
            droCapDo.DataBind();
            droDuongNPPLL.DataSource = dll.DS();
            droDuongNPPLL.DataBind();
            droDuongNPPTT.DataSource = dtt.DS();
            droDuongNPPTT.DataBind();
            droXaNPPLL.DataSource = xpll.DS("0000");
            droXaNPPLL.DataBind();
            droXaNPPTT.DataSource = xptt.DS("0000");
            droXaNPPTT.DataBind();
            droHuyenNPPLL.DataSource = hll.DS_TheoTinh("00");
            droHuyenNPPLL.DataBind();
            droHuyenNPPTT.DataSource = htt.DS_TheoTinh("00");
            droHuyenNPPTT.DataBind();
            droTinhNPPLL.DataSource = tll.DS();
            droTinhNPPLL.DataBind();
            droTinhNPPTT.DataSource = ttt.DS();
            droTinhNPPTT.DataBind();
            droNhaBaoTro.DataSource = npp.DS();
            droNhaBaoTro.DataBind();
            droNBT.DataSource = npp.DS();
            droNBT.DataBind();
            griNPP_Moi.Visible = false;
            griNPP_ThanhTichMoi.Visible = false;
            griNPP_SapHetHan.Visible = false;
            pnlChiTietNPP.Visible = false;
        }
    }
    protected void griNPP_Moi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNPP_Moi.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_Moi.DataSource = npp.DS_Moi();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_Moi.DataSource = npp.DS_Moi();
        }
        griNPP_Moi.DataBind();
    }
    protected void griNPP_ThanhTichMoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNPP_ThanhTichMoi.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_ThanhTichMoi.DataSource = npp.DS_ThanhTichMoi();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_ThanhTichMoi.DataSource = npp.DS_ThanhTichMoi();
        }
        griNPP_ThanhTichMoi.DataBind();
    }
    protected void btnNPP_Moi_Click(object sender, EventArgs e)
    {
        griNPP_Moi.Visible = true;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_Moi.DataSource = npp.DS_Moi();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_Moi.DataSource = npp.DS_Moi();
        }
        griNPP_Moi.DataBind();
        griNPP_ThanhTichMoi.Visible = false;
        griNPP_SapHetHan.Visible = false;
        pnlChiTietNPP.Visible = false;
    }
    protected void btnNPP_ThanhTichMoi_Click(object sender, EventArgs e)
    {
        griNPP_ThanhTichMoi.Visible = true;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_ThanhTichMoi.DataSource = npp.DS_ThanhTichMoi();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.TuNgay = txtTuNgay.Text;
            npp.DenNgay = txtDenNgay.Text;
            griNPP_ThanhTichMoi.DataSource = npp.DS_ThanhTichMoi();
        }
        griNPP_ThanhTichMoi.DataBind();
        griNPP_Moi.Visible = false;
        griNPP_SapHetHan.Visible = false;
        pnlChiTietNPP.Visible = false;
    }
    protected void btnNPP_SapHetHan_Click(object sender, EventArgs e)
    {
        griNPP_SapHetHan.Visible = true;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            griNPP_SapHetHan.DataSource = npp.DS_CanhBao();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            griNPP_ThanhTichMoi.DataSource = npp.DS_CanhBao();
        }
        griNPP_SapHetHan.DataBind();
        griNPP_ThanhTichMoi.Visible = false;
        griNPP_Moi.Visible = false;
        pnlChiTietNPP.Visible = false;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = false;
    }
    protected void griNPP_Moi_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        npp.MaNPP = griNPP_Moi.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        //txtNgaySinh.Text = npp.NgaySinh;
        string temp1 = npp.NgaySinh.ToString().Replace("12:00:00 AM", "");
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (npp.GioiTinh == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;
        /*if (griNhaPhanPhoi.Rows[griNhaPhanPhoi.SelectedIndex].Cells[4]. == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;*/
        /*if (npp.GioiTinh == null)
        {rdoNu.Checked = true ;
            rdoNam.Checked = false;}
        else
            rdoNam.Checked = npp.GioiTinh;*/
        imgAnhNPP.ImageUrl = "~/src/emp/" + npp.AnhNPP;
        txtCMND.Text = npp.CMND;
        txtCMND.Enabled = false;
        txtSoDT.Text = npp.SoDT;
        txtEmail.Text = npp.Email;
        //txtNgayKyThe.Text = npp.NgayKyThe;
        string temp2 = npp.NgayKyThe.ToString().Replace("12:00:00 AM", "");
        txtNgayKyThe.Text = temp2;
        txtNgayKyThe.Enabled = false;
        //txtNgayHetHan.Text = npp.NgayHetHan;
        string temp3 = npp.NgayHetHan.ToString().Replace("12:00:00 AM", "");
        txtNgayHetHan.Text = temp3;
        txtNgayHetHan.Enabled = false;
        txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
        txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
        npp.MaNPP = npp.MaNBT;
        droNBT.SelectedValue = npp.MaNPP.ToString();
        cd.MaCD = npp.MaCD;
        droCapDo.SelectedValue = cd.MaCD.ToString();
        //Tinh
        tll.MaTinh = npp.MaTinhNPPLL;
        droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
        ttt.MaTinh = npp.MaTinhNPPTT;
        droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
        //Huyen
        // droTinhNPPLL_SelectedIndexChanged(sender, e);
        droHuyenNPPLL.DataSource = hll.DS_TheoTinh(tll.MaTinh);
        droHuyenNPPLL.DataBind();
        // droTinhNPPTT_SelectedIndexChanged(sender, e);
        droHuyenNPPTT.DataSource = htt.DS_TheoTinh(ttt.MaTinh);
        droHuyenNPPTT.DataBind();
        hll.MaHuyen = npp.MaHuyenNPPLL;
        droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
        htt.MaHuyen = npp.MaHuyenNPPTT;
        droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
        //Xa
        //droHuyenNPPLL_SelectedIndexChanged(sender, e);
        droXaNPPLL.DataSource = xpll.DS(hll.MaHuyen);
        droXaNPPLL.DataBind();
        //droHuyenNPPTT_SelectedIndexChanged(sender, e);
        droXaNPPTT.DataSource = xptt.DS(htt.MaHuyen);
        droXaNPPTT.DataBind();
        xpll.MaXa = npp.MaXaNPPLL;
        droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
        xptt.MaXa = npp.MaXaNPPTT;
        droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
        //Duong
        dll.MaDuong = npp.MaDuongNPPLL;
        droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
        dtt.MaDuong = npp.MaDuongNPPTT;
        droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
    }
    protected void griNPP_ThanhTichMoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        npp.MaNPP = griNPP_ThanhTichMoi.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        //txtNgaySinh.Text = npp.NgaySinh;
        string temp1 = npp.NgaySinh.ToString().Replace("12:00:00 AM", "");
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (npp.GioiTinh == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;
        /*if (griNhaPhanPhoi.Rows[griNhaPhanPhoi.SelectedIndex].Cells[4]. == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;*/
        /*if (npp.GioiTinh == null)
        {rdoNu.Checked = true ;
            rdoNam.Checked = false;}
        else
            rdoNam.Checked = npp.GioiTinh;*/
        imgAnhNPP.ImageUrl = "~/src/emp/" + npp.AnhNPP;
        txtCMND.Text = npp.CMND;
        txtCMND.Enabled = false;
        txtSoDT.Text = npp.SoDT;
        txtEmail.Text = npp.Email;
        //txtNgayKyThe.Text = npp.NgayKyThe;
        string temp2 = npp.NgayKyThe.ToString().Replace("12:00:00 AM", "");
        txtNgayKyThe.Text = temp2;
        txtNgayKyThe.Enabled = false;
        //txtNgayHetHan.Text = npp.NgayHetHan;
        string temp3 = npp.NgayHetHan.ToString().Replace("12:00:00 AM", "");
        txtNgayHetHan.Text = temp3;
        txtNgayHetHan.Enabled = false;
        txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
        txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
        npp.MaNPP = npp.MaNBT;
        droNBT.SelectedValue = npp.MaNPP.ToString();
        cd.MaCD = npp.MaCD;
        droCapDo.SelectedValue = cd.MaCD.ToString();
        //Tinh
        tll.MaTinh = npp.MaTinhNPPLL;
        droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
        ttt.MaTinh = npp.MaTinhNPPTT;
        droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
        //Huyen
        // droTinhNPPLL_SelectedIndexChanged(sender, e);
        droHuyenNPPLL.DataSource = hll.DS_TheoTinh(tll.MaTinh);
        droHuyenNPPLL.DataBind();
        // droTinhNPPTT_SelectedIndexChanged(sender, e);
        droHuyenNPPTT.DataSource = htt.DS_TheoTinh(ttt.MaTinh);
        droHuyenNPPTT.DataBind();
        hll.MaHuyen = npp.MaHuyenNPPLL;
        droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
        htt.MaHuyen = npp.MaHuyenNPPTT;
        droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
        //Xa
        //droHuyenNPPLL_SelectedIndexChanged(sender, e);
        droXaNPPLL.DataSource = xpll.DS(hll.MaHuyen);
        droXaNPPLL.DataBind();
        //droHuyenNPPTT_SelectedIndexChanged(sender, e);
        droXaNPPTT.DataSource = xptt.DS(htt.MaHuyen);
        droXaNPPTT.DataBind();
        xpll.MaXa = npp.MaXaNPPLL;
        droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
        xptt.MaXa = npp.MaXaNPPTT;
        droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
        //Duong
        dll.MaDuong = npp.MaDuongNPPLL;
        droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
        dtt.MaDuong = npp.MaDuongNPPTT;
        droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
    }
    protected void griNPP_SapHetHan_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        npp.MaNPP = griNPP_SapHetHan.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        //txtNgaySinh.Text = npp.NgaySinh;
        string temp1 = npp.NgaySinh.ToString().Replace("12:00:00 AM", "");
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (npp.GioiTinh == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;
        /*if (griNhaPhanPhoi.Rows[griNhaPhanPhoi.SelectedIndex].Cells[4]. == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;*/
        /*if (npp.GioiTinh == null)
        {rdoNu.Checked = true ;
            rdoNam.Checked = false;}
        else
            rdoNam.Checked = npp.GioiTinh;*/
        imgAnhNPP.ImageUrl = "~/src/emp/" + npp.AnhNPP;
        txtCMND.Text = npp.CMND;
        txtCMND.Enabled = false;
        txtSoDT.Text = npp.SoDT;
        txtEmail.Text = npp.Email;
        //txtNgayKyThe.Text = npp.NgayKyThe;
        string temp2 = npp.NgayKyThe.ToString().Replace("12:00:00 AM", "");
        txtNgayKyThe.Text = temp2;
        txtNgayKyThe.Enabled = false;
        //txtNgayHetHan.Text = npp.NgayHetHan;
        string temp3 = npp.NgayHetHan.ToString().Replace("12:00:00 AM", "");
        txtNgayHetHan.Text = temp3;
        txtNgayHetHan.Enabled = false;
        txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
        txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
        npp.MaNPP = npp.MaNBT;
        droNBT.SelectedValue = npp.MaNPP.ToString();
        cd.MaCD = npp.MaCD;
        droCapDo.SelectedValue = cd.MaCD.ToString();
        //Tinh
        tll.MaTinh = npp.MaTinhNPPLL;
        droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
        ttt.MaTinh = npp.MaTinhNPPTT;
        droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
        //Huyen
        // droTinhNPPLL_SelectedIndexChanged(sender, e);
        droHuyenNPPLL.DataSource = hll.DS_TheoTinh(tll.MaTinh);
        droHuyenNPPLL.DataBind();
        // droTinhNPPTT_SelectedIndexChanged(sender, e);
        droHuyenNPPTT.DataSource = htt.DS_TheoTinh(ttt.MaTinh);
        droHuyenNPPTT.DataBind();
        hll.MaHuyen = npp.MaHuyenNPPLL;
        droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
        htt.MaHuyen = npp.MaHuyenNPPTT;
        droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
        //Xa
        //droHuyenNPPLL_SelectedIndexChanged(sender, e);
        droXaNPPLL.DataSource = xpll.DS(hll.MaHuyen);
        droXaNPPLL.DataBind();
        //droHuyenNPPTT_SelectedIndexChanged(sender, e);
        droXaNPPTT.DataSource = xptt.DS(htt.MaHuyen);
        droXaNPPTT.DataBind();
        xpll.MaXa = npp.MaXaNPPLL;
        droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
        xptt.MaXa = npp.MaXaNPPTT;
        droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
        //Duong
        dll.MaDuong = npp.MaDuongNPPLL;
        droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
        dtt.MaDuong = npp.MaDuongNPPTT;
        droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
    }
}