using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; 

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
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.HoTenNPP = Session["HoTenNPPSearch"].ToString();
            griNhaPhanPhoi.DataSource = npp.TimTheoTen();
            griNhaPhanPhoi.DataBind();
            cd.MaCD = 0;
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
        }
    }
    protected void griNhaPhanPhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = true;
        txtNgayKyThe0_CalendarExtender.SelectedDate = DateTime.Today;
        if (Session["MaNPPClick"] == null || npp.MaNBT == Session["MaNPP"])
        {
            btnXoa.Visible = true;
            //show-popup: cho nút xóa ẩn
            btnSua.Visible = true;
            lbtSP.Visible = true;
            lbtCTSDR.Visible = true;
        }
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
        if (npp.MaNBT == Session["MaNPP"])
        {
            if (npp.SL_CanhBao() != 0)
                btnGHT.Visible = true;
        }
        if (Session["MaNPP"].ToString() == "0000000")//|| npp.MaNBT == Session["MaNPP"].ToString()
        {
            btnSua.Visible = true;
            if (npp.SL_CanhBao() != 0)
                btnGHT.Visible = true;
            droNBT.Visible = true;
            droNBT.Enabled = true;
            btnXoa.Visible = true;
            lbtSP.Visible = true;
            lbtCTSDR.Visible = true;
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
    }
    protected void griNhaPhanPhoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNhaPhanPhoi.PageIndex = e.NewPageIndex;
        griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
        griNhaPhanPhoi.DataBind();
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
            npp.CMND = Session["CMND"].ToString();
            if (npp.TimXoa_MaNPP() == false)
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
            if (Session["MaNPP"] == "0000000")
            {
                droNBT.Enabled = true;
                npp.MaNBT = droNBT.SelectedValue;
                npp.Sua_NhaBaoTro();
            }
            else
                droNBT.Enabled = false;
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            pnlChiTietNPP.Visible = false;
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
                if (Session["MaNPP"] == "0000000")
                {
                    droNBT.Enabled = true;
                    npp.MaNBT = droNBT.SelectedValue;
                    npp.Sua_NhaBaoTro();
                }
                else
                    droNBT.Enabled = false;
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
                griNhaPhanPhoi.DataBind();
                pnlChiTietNPP.Visible = false;
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
        Session["MaLSP"] = "0";
        Response.Redirect("~/User/SanPham.aspx?MaADA=" + Session["MaNPPClick"] + "MaLSP=0");
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
        npp.NgayHetHan = txtNgayHetHan.Text;
        npp.Sua_NgayHetHan();
        lblCanhBao.Text = npp.ThongBao;
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
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        Session["MaNPPClick"] = griNhaPhanPhoi.SelectedValue.ToString();
        Response.Redirect("~/User/TrangChu.aspx?MaADA=" + Session["MaNPPClick"]);
    }
}