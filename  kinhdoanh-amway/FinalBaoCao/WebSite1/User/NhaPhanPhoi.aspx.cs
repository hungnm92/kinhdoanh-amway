﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;

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
            Session["MaKH"] = null;
            if (Session["MaCD"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
            {
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
                lbtThemMoi.Visible = true;
            }
            else
            {
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPPClick"].ToString(), int.Parse(Session["MaCD"].ToString()));
                lbtThemMoi.Visible = false;
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem: " + npp.HoNPP + " " + npp.TenNPP;
            }
            griNhaPhanPhoi.DataBind();
            cd.MaCD = int.Parse(Session["MaCD"].ToString());
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
        }
    }
    protected void griNhaPhanPhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = true;
        txtNgayKyThe0_CalendarExtender.SelectedDate = DateTime.Today;
        if (Session["MaNPPClick"] == null)
        {
            btnXoa.Visible = true;
            //show-popup: cho nút xóa ẩn
            btnSua.Visible = true;
            lbtSP.Visible = true;
            lbtCTSDR.Visible = true;
        }
        lbtThemMoi.Visible = false;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
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
        txtNgayHetHan.Enabled = false;
        txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
        txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
        cd.MaCD = npp.MaCD;
        droCapDo.SelectedValue = cd.MaCD.ToString();
        npp.NgayHetHan = temp3;
        npp.CanhBao();
        lblCanhBao.Text = npp.ThongBao; // cảnh báo gia hạn thẻ.
        if (Session["MaNPPClick"] == null || npp.MaNBT == Session["MaNPP"])
        {
            if (npp.SL_CanhBao() != 0)
                btnGHT.Visible = true;
        }
        //Tinh
        tll.MaTinh = npp.MaTinhNPPLL;
        droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
        ttt.MaTinh = npp.MaTinhNPPTT;
        droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
        //Huyen
        droTinhNPPLL_SelectedIndexChanged(sender, e);
        //droHuyenNPPLL.DataSource = hll.DS_TheoTinh(tll.MaTinh);
        // droHuyenNPPLL.DataBind();           
        droTinhNPPTT_SelectedIndexChanged(sender, e);
        //droHuyenNPPTT.DataSource = htt.DS_TheoTinh(ttt.MaTinh);
        //droHuyenNPPTT.DataBind();
        hll.MaHuyen = npp.MaHuyenNPPLL;
        droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
        htt.MaHuyen = npp.MaHuyenNPPTT;
        droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
        //Xa
        droHuyenNPPLL_SelectedIndexChanged(sender, e);
        //droXaNPPLL.DataSource = xpll.DS(hll.MaHuyen);
        //droXaNPPLL.DataBind();
        droHuyenNPPTT_SelectedIndexChanged(sender, e);
        //droXaNPPTT.DataSource = xptt.DS(htt.MaHuyen);
        //droXaNPPTT.DataBind();
        xpll.MaXa = npp.MaXaNPPLL;
        droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
        xptt.MaXa = npp.MaXaNPPTT;
        droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
        //Duong
        dll.MaDuong = npp.MaDuongNPPLL;
        droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
        dtt.MaDuong = npp.MaDuongNPPTT;
        droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
        npp.MaNPP = npp.MaNBT;
        droNBT.SelectedValue = npp.MaNPP.ToString();
        btnThem.Visible = false;
    }
    protected void griNhaPhanPhoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNhaPhanPhoi.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
        }
        else
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPPClick"].ToString(), int.Parse(Session["MaCD"].ToString()));
        griNhaPhanPhoi.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
       // Session["URL"] = "SP_" + sp.TempID + "file";
        txtNgaySinh.Enabled = true;
        txtNgaySinh.ReadOnly = false;
        txtCMND.Enabled = true;
        txtCMND.ReadOnly = false;
        txtNgayKyThe.ReadOnly = false;
        txtNgayKyThe.Enabled = true;
        txtMaNPP.Enabled = true;
        txtMaNPP.ReadOnly = false;
        pnlChiTietNPP.Visible = true;
        lbtThemMoi.Visible = false;
        btnGHT.Visible = false;
        lblCanhBao.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        //show-popup: cho nút xóa ẩn.
        btnSua.Visible = false;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        btnChuyenMacDinh.Visible = false;
        btnChuyenTheoYeuCau.Visible = false;
        txtMaNPP.Text = "";
        txtMaNPP.Enabled = true;
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
        qtcd.MaCD = 0;
        imgAnhNPP.ImageUrl = "~/src/emp/";
        txtNgaySinh.Text = "";
        txtNgaySinh.Enabled = true;
        txtCMND.Text = "";
        txtCMND.Enabled = true;
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtNgayKyThe.Enabled = true;
        txtNgayHetHan.Text = "";
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
        droCapDo.Enabled = false;
        droNBT.SelectedValue = Session["MaNPP"].ToString();
        droNBT.Enabled = false;
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaADA = string.IsNullOrWhiteSpace(txtMaNPP.Text);
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        bool bNgayKyThe = string.IsNullOrWhiteSpace(txtNgayKyThe.Text);
        if (bMaADA == false && bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && bNgayKyThe == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = txtMaNPP.Text;
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            npp.NgaySinh = txtNgaySinh.Text;
            if (rdoNam.Checked == true)
                npp.GioiTinh = true;
            else
                npp.GioiTinh = false;
            string DuongDan = "";
            string ReName = txtMaNPP.Text;
            DuongDan = Server.MapPath("~/src/emp/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhNPP.SaveAs(DuongDan);
            npp.AnhNPP = ReName + ".jpg";
            npp.CMND = txtCMND.Text;
            npp.SoDT = txtSoDT.Text;
            npp.Email = txtEmail.Text;
            npp.NgayKyThe = txtNgayKyThe.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;     
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            npp.MaNBT = Session["MaNPP"].ToString();
            npp.Them();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            pnlChiTietNPP.Visible = false;
            lbtThemMoi.Visible = true;
            npp.MaNPP = "1";
            npp.Tim_MaNPP();
            if (npp.MaNPP == txtMaNPP.Text)
            {
                qtcd.MaNPP = npp.MaNPP;
                qtcd.MaCD = 0;
                qtcd.ThoiGian = txtNgayKyThe.Text;
                qtcd.Them();
                Response.Redirect("~/User/NhaPhanPhoi.aspx");
            }
        }
        else
        {
            if (fileAnhNPP.HasFile == false)
            {
                lblTB.Visible = true;
                lblTB.Text = "Bạn cần thêm ảnh.";
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Ở các vị trí * bắt buộc bạn phải nhập.";
            }
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if (npp.SL_NhaPhanPhoi(griNhaPhanPhoi.SelectedValue.ToString()) == 0)
        {
            npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
            Session["CMND"] = txtCMND.Text;
            nppsd.MaNPP = npp.MaNPP;
            nppsd.Xoa_DS();
            npp.CT();
            khsd.MaNPP = npp.MaNPP;
            khsd.MaNPPMoi = npp.MaNBT;
            khsd.Sua_NPP();
            dthu.MaNPP = npp.MaNPP;
            dthu.Xoa_DS();
            dt.MaNPP = npp.MaNPP;
            dt.Xoa_DS();
            cs.MaNPP = npp.MaNPP;
            cs.MaNPPMoi = npp.MaNBT;
            cs.Sua_NPP();
            qtcd.MaNPP = npp.MaNPP;
            qtcd.Xoa_DS();
            npp.Xoa();
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;// không thực hiện được tại vì nó đã response.
            txtMaNPP.Text = "";
            txtHoNPP.Text = "";
            txtTenNPP.Text = "";
            imgAnhNPP.ImageUrl = "~/src/emp/";
            txtNgaySinh.Text = "";
            txtCMND.Text = "";
            txtSoDT.Text = "";
            txtEmail.Text = "";
            txtNgayKyThe.Text = "";
            txtNgayHetHan.Text = "";
            txtSoNhaNPPTT.Text = "";
            txtSoNhaNPPLL.Text = "";
            pnlChiTietNPP.Visible = false;
            lbtThemMoi.Visible = true;
            npp.CMND = Session["CMND"].ToString();
            if(npp.TimXoa_MaNPP() == false)
                Response.Redirect("~/User/NhaPhanPhoi.aspx");
        }
        else
        {
            lblXoa.Text = "Nhà phân phối có nhánh con, vui lòng chọn chuyển mặc định HOẶC chọn Nhà Bảo Trợ rồi chọn chuyển theo yêu cầu";
            btnChuyenMacDinh.Visible = true;
            btnChuyenTheoYeuCau.Visible = true;
            droNhaBaoTro.Visible = true;
            btnXoa.Visible = false;
            
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = false;
        if (Session["MaNPPClick"] == null)
            lbtThemMoi.Visible = true;
        else
            lbtThemMoi.Visible = false;
        lblTB.Visible = false;
        rdoNam.Checked = false;
        rdoNu.Checked = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        if (bHoNPP == false && bTenNPP == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            if(rdoNam.Checked == true)
                npp.GioiTinh = true;
            else
                npp.GioiTinh = false;
            string DuongDan = "";
            string ReName = txtMaNPP.Text;
            DuongDan = Server.MapPath("~/src/emp/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhNPP.SaveAs(DuongDan);
            npp.AnhNPP = ReName + ".jpg";
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
            npp.MaNBT = Session["MaNPP"].ToString();
            npp.Sua();
            qtcd.MaCD = int.Parse(droCapDo.SelectedValue);
            qtcd.MaNPP = npp.MaNPP;
            txtNgayKyThe0_CalendarExtender.SelectedDate = DateTime.Today;
            qtcd.ThoiGian = txtNgayKyThe0.Text;//lấy ngày hệ thống
            qtcd.Them();
            lblTBQTCD.Visible = true;
            lblTBQTCD.Text = qtcd.ThongBao;
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            pnlChiTietNPP.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
            if (bHoNPP == false && bTenNPP == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == false)
            {
                npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
                npp.CT();
                string temp = npp.AnhNPP.ToString();
                npp.HoNPP = txtHoNPP.Text;
                npp.TenNPP = txtTenNPP.Text;
                if (rdoNam.Checked == true)
                    npp.GioiTinh = true;
                else
                    npp.GioiTinh = false;
                npp.AnhNPP = temp;
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
                npp.MaNBT = Session["MaNPP"].ToString();
                npp.Sua();
                qtcd.MaCD = int.Parse(droCapDo.SelectedValue);
                qtcd.MaNPP = npp.MaNPP;
                qtcd.ThoiGian = System.DateTime.Now.ToLongTimeString();// lấy time mặc định tại hệ thống.
                qtcd.Them();
                lblTBQTCD.Visible = true;
                lblTBQTCD.Text = qtcd.ThongBao;
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
                griNhaPhanPhoi.DataBind();
                pnlChiTietNPP.Visible = false;
                lbtThemMoi.Visible = true;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Các vị trí * là bắt buộc bạn nhập.";
            }
    }
    protected void btnChuyenMacDinh_Click(object sender, EventArgs e)
    {
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        Session["CMND"] = txtCMND.Text;
        npp.CT();
        npp.Sua_NhaBaoTro();
        nppsd.MaNPP = npp.MaNPP;
        nppsd.Xoa_DS();
        khsd.MaNPP = npp.MaNPP;
        khsd.MaNPPMoi = npp.MaNBT;
        khsd.Sua_NPP();
        dthu.MaNPP = npp.MaNPP;
        dthu.Xoa_DS();
        dt.MaNPP = npp.MaNPP;
        dt.Xoa_DS();
        cs.MaNPP = npp.MaNPP;
        cs.MaNPPMoi = npp.MaNBT;
        cs.Sua_NPP();
        qtcd.MaNPP = npp.MaNPP;
        qtcd.Xoa_DS();
        npp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = npp.ThongBao;
        txtMaNPP.Text = "";
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
        imgAnhNPP.ImageUrl = "~/src/emp/";
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtNgayHetHan.Text = "";
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
        pnlChiTietNPP.Visible = false;
        lbtThemMoi.Visible = true;
        npp.CMND = Session["CMND"].ToString();
        if (npp.TimXoa_MaNPP() == false)
            Response.Redirect("~/User/NhaPhanPhoi.aspx");
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Chuyển không thành công.";
        }
    }
    protected void btnChuyenTheoYeuCau_Click(object sender, EventArgs e)
    {
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        Session["CMND"] = txtCMND.Text;
        npp.CT();
        npp.MaNBT = droNhaBaoTro.SelectedValue;
        npp.Sua_NhaBaoTro();
        nppsd.MaNPP = npp.MaNPP;
        nppsd.Xoa_DS();
        khsd.MaNPP = npp.MaNPP;
        khsd.MaNPPMoi = droNhaBaoTro.SelectedValue;
        khsd.Sua_NPP();
        dthu.MaNPP = npp.MaNPP;
        dthu.Xoa_DS();
        dt.MaNPP = npp.MaNPP;
        dt.Xoa_DS();
        cs.MaNPP = npp.MaNPP;
        cs.MaNPPMoi = droNhaBaoTro.SelectedValue;
        cs.Sua_NPP();
        qtcd.MaNPP = npp.MaNPP;
        qtcd.Xoa_DS();
        npp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = npp.ThongBao;
        txtMaNPP.Text = "";
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
        imgAnhNPP.ImageUrl = "~/src/emp/";
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtNgayHetHan.Text = "";
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
        pnlChiTietNPP.Visible = false;
        lbtThemMoi.Visible = true;
        npp.CMND = Session["CMND"].ToString();
        if (npp.TimXoa_MaNPP() == false)
            Response.Redirect("~/User/NhaPhanPhoi.aspx");
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Chuyển không thành công.";
        }
    }
    protected void lbtSPSD_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/SanPham_DaDung.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void lbtTTDT_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/ChuongTrinh_DaoTao.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void lbtTTDThu_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/DoanhThu.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void lbtSP_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Session["MaLMH"] = "0";
        Response.Redirect("~/User/SanPham.aspx?MaADA=" + Session["MaNPPClick"] + "MaLMH=0");
    }
    protected void lblSPGY_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/SanPham_GoiY.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void lbtCTSDR_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/ChuongTrinh_SapDienRa.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void lbtTTCS_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/ChuongTrinh_ChamSoc.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void btnGHT_Click(object sender, EventArgs e)
    {
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        npp.CT();
        npp.Sua_NgayHetHan();
    }
    protected void lbtQTCD_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/QuaTrinhCD.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void droTinhNPPLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
        droHuyenNPPLL.DataSource = hll.DS_TheoTinh(npp.MaTinhNPPLL);
        droHuyenNPPLL.DataBind();
        droXaNPPLL.DataSource = xpll.DS(droHuyenNPPLL.SelectedValue);
        droXaNPPLL.DataBind();
    }
    protected void droHuyenNPPLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
        droXaNPPLL.DataSource = xpll.DS(npp.MaHuyenNPPLL);
        droXaNPPLL.DataBind();
    }
    protected void droTinhNPPTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
        droHuyenNPPTT.DataSource = htt.DS_TheoTinh(npp.MaTinhNPPTT);
        droHuyenNPPTT.DataBind();
        droXaNPPTT.DataSource = xptt.DS(droHuyenNPPTT.SelectedValue);
        droXaNPPTT.DataBind();
    }
    protected void droHuyenNPPTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
        droXaNPPTT.DataSource = xptt.DS(npp.MaHuyenNPPTT);
        droXaNPPTT.DataBind();
    }
    /// Hàm xuất dữ liệu từ gridview ra pdf
    private void XuatDuLieuGridRaPDF(GridView MyGridview)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        MyGridview.AllowPaging = false;
        MyGridview.DataBind();
        MyGridview.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/TrangChu.aspx?MaADA=" + Session["MaNPPClick"]);
    }
    protected void btnThemD_Click(object sender, EventArgs e)
    {
        if ((string.IsNullOrWhiteSpace(txtMaD.Text) == false) && (string.IsNullOrWhiteSpace(txtTenD.Text) == false))
        {
            dll.MaDuong = txtMaD.Text;
            dll.TenDuong = txtTenD.Text;
            dll.Them();
            lblTB.Visible = true;
            lblTB.Text = dll.ThongBao;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập mã đường hoặc tên đường.";
        }
    }
    protected void btnThemXP_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTenX.Text) == false)
        {
            xptt.MaHuyen = droHuyenNPPTT.SelectedValue.ToString();
            xptt.TenXa = txtTenX.Text;
            xptt.Them();
            lblTB.Visible = true;
            lblTB.Text = xptt.ThongBao;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập tên Xã/Phường.";
        }
    }
    protected void btnThemH_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTenH.Text) == false)
        {
            htt.MaTinh = droTinhNPPTT.SelectedValue.ToString();
            htt.TenHuyen = txtTenH.Text;
            htt.Them();
            lblTB.Visible = true;
            lblTB.Text = htt.ThongBao;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập tên Huyện.";
        }
    }
}