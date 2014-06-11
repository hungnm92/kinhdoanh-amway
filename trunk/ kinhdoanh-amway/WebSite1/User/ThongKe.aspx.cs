using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Subgurim.Controles;

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
            //DataTable dt1 = this.GetData("select MaNPP,  ViDo, KinhDo, HoNPP +' '+ TenNPP as HoTen from NhaPhanPhoi where ViDo >0 and KinhDo > 0");
            if (Session["MaNPPClick"] == null)//Gán MaNPP vào để hiển thị GoogleMap khi của NPP tuyến dưới hoặc chính NPP Login
                npp.MaNPP = Session["MaNPP"].ToString();
            else
                npp.MaNPP = Session["MaNPPClick"].ToString();
            if (Request.QueryString["ThanhTichMoi"] == "Dung")//Kiểm tra session thanhtichmoi = dung thì hiện gri thành tích mới.
            {
                griNPP_ThanhTichMoi.Visible = true;
                griNPP_ThanhTichMoi.DataSource = npp.DS_BaoTro_NEW();//Sử dụng npp.MaNPP ở trên
                griNPP_ThanhTichMoi.DataBind();
            }
            rptMarkers.DataSource = npp.DS_GoogleMap();//Sử dụng npp.MaNPP ở trên
            rptMarkers.DataBind();
            lblTB.Visible = false;
        }
    }
    /*private DataTable GetData(string query)
    {
        string conString = "server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn;";
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;

                sda.SelectCommand = cmd;
                using (DataTable dt1 = new DataTable())
                {
                    sda.Fill(dt1);
                    return dt1;
                }
            }
        }
    }*/
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
        bool bTuNgay = string.IsNullOrWhiteSpace(txtTuNgay.Text);
        bool bDenNgay = string.IsNullOrWhiteSpace(txtDenNgay.Text);
        if (bTuNgay == false && bDenNgay == false)
        {
            lblTB.Visible = false;
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
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Vui lòng nhập ngày bắt đầu, ngày kết thúc.";
        }
    }
    protected void btnNPP_ThanhTichMoi_Click(object sender, EventArgs e)
    {
        bool bTuNgay = string.IsNullOrWhiteSpace(txtTuNgay.Text);
        bool bDenNgay = string.IsNullOrWhiteSpace(txtDenNgay.Text);
        if (bTuNgay == false && bDenNgay == false)
        {
            lblTB.Visible = false;
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
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Vui lòng nhập ngày bắt đầu, ngày kết thúc.";
        }
    }
    protected void btnNPP_SapHetHan_Click(object sender, EventArgs e)
    {
        lblTB.Visible = false;
        griNPP_SapHetHan.Visible = true;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            griNPP_SapHetHan.DataSource = npp.DS_SapHetHan();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            griNPP_ThanhTichMoi.DataSource = npp.DS_SapHetHan();
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
        btnThoat.Visible = true;
        npp.MaNPP = griNPP_Moi.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        //Xem quá trình cấp độ
        griQTCD.DataSource = qtcd.DS(npp.MaNPP);
        griQTCD.DataBind();
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        //txtNgaySinh.Text = npp.NgaySinh;
        string temp1 = npp.NgaySinh.ToString().Replace(" 12:00:00 AM", "");
        temp1 = temp1.Substring(8, 2) + "/" + temp1.Substring(5, 2) + "/" + temp1.Substring(0, 4);
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (npp.GioiTinh == true)
        {
            rdoNu.Checked = false;
            rdoNam.Checked = true;
        }
        else
        {
            rdoNam.Checked = false;
            rdoNu.Checked = true;
        }
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
        string temp2 = npp.NgayKyThe.ToString().Replace(" 12:00:00 AM", "");
        temp2 = temp2.Substring(8, 2) + "/" + temp2.Substring(5, 2) + "/" + temp2.Substring(0, 4);
        txtNgayKyThe.Text = temp2;
        txtNgayKyThe.Enabled = false;
        //txtNgayHetHan.Text = npp.NgayHetHan;
        string temp3 = npp.NgayHetHan.ToString().Replace(" 12:00:00 AM", "");
        temp3 = temp3.Substring(8, 2) + "/" + temp3.Substring(5, 2) + "/" + temp3.Substring(0, 4);
        txtNgayHetHan.Text = temp3;
        npp.NgayHetHan = temp3;
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
        btnThoat.Visible = true;
        npp.MaNPP = griNPP_ThanhTichMoi.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        //Xem quá trình cấp độ
        griQTCD.DataSource = qtcd.DS(npp.MaNPP);
        griQTCD.DataBind();
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        //txtNgaySinh.Text = npp.NgaySinh;
        string temp1 = npp.NgaySinh.ToString().Replace(" 12:00:00 AM", "");
        temp1 = temp1.Substring(8, 2) + "/" + temp1.Substring(5, 2) + "/" + temp1.Substring(0, 4);
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (npp.GioiTinh == true)
        {
            rdoNu.Checked = false;
            rdoNam.Checked = true;
        }
        else
        {
            rdoNam.Checked = false;
            rdoNu.Checked = true;
        }
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
        string temp2 = npp.NgayKyThe.ToString().Replace(" 12:00:00 AM", "");
        temp2 = temp2.Substring(8, 2) + "/" + temp2.Substring(5, 2) + "/" + temp2.Substring(0, 4);
        txtNgayKyThe.Text = temp2;
        txtNgayKyThe.Enabled = false;
        //txtNgayHetHan.Text = npp.NgayHetHan;
        string temp3 = npp.NgayHetHan.ToString().Replace(" 12:00:00 AM", "");
        temp3 = temp3.Substring(8, 2) + "/" + temp3.Substring(5, 2) + "/" + temp3.Substring(0, 4);
        txtNgayHetHan.Text = temp3;
        npp.NgayHetHan = temp3;
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
        btnThoat.Visible = true;
        npp.MaNPP = griNPP_SapHetHan.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        //Xem quá trình cấp độ
        griQTCD.DataSource = qtcd.DS(npp.MaNPP);
        griQTCD.DataBind();
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        //txtNgaySinh.Text = npp.NgaySinh;
        string temp1 = npp.NgaySinh.ToString().Replace(" 12:00:00 AM", "");
        temp1 = temp1.Substring(8, 2) + "/" + temp1.Substring(5, 2) + "/" + temp1.Substring(0, 4);
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (npp.GioiTinh == true)
        {
            rdoNu.Checked = false;
            rdoNam.Checked = true;
        }
        else
        {
            rdoNam.Checked = false;
            rdoNu.Checked = true;
        }
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
        string temp2 = npp.NgayKyThe.ToString().Replace(" 12:00:00 AM", "");
        temp2 = temp2.Substring(8, 2) + "/" + temp2.Substring(5, 2) + "/" + temp2.Substring(0, 4);
        txtNgayKyThe.Text = temp2;
        txtNgayKyThe.Enabled = false;
        //txtNgayHetHan.Text = npp.NgayHetHan;
        string temp3 = npp.NgayHetHan.ToString().Replace(" 12:00:00 AM", "");
        temp3 = temp3.Substring(8, 2) + "/" + temp3.Substring(5, 2) + "/" + temp3.Substring(0, 4);
        txtNgayHetHan.Text = temp3;
        npp.NgayHetHan = temp3;
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