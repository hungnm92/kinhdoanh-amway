using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_KhachHang : System.Web.UI.Page
{
    webdoan.KhachHang kh = new webdoan.KhachHang();
    webdoan.CapDo cd = new webdoan.CapDo();
    webdoan.Duong dll = new webdoan.Duong();
    webdoan.Duong dtt = new webdoan.Duong();
    webdoan.XaPhuong xpll = new webdoan.XaPhuong();
    webdoan.XaPhuong xptt = new webdoan.XaPhuong();
    webdoan.Huyen hll = new webdoan.Huyen();
    webdoan.Huyen htt = new webdoan.Huyen();
    webdoan.Tinh tll = new webdoan.Tinh();
    webdoan.Tinh ttt = new webdoan.Tinh();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    webdoan.DaoTao dt = new webdoan.DaoTao();
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["Loai"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
            {
                griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));
                lbtThemMoi.Visible = true;
            }
            else
            {
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem khách hàng của: " + npp.HoNPP + " " + npp.TenNPP;
                griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPPClick"].ToString(), bool.Parse(Session["Loai"].ToString()));
            }
            griKhachHang.DataBind();
            droDuongKHLL.DataSource = dll.DS();
            droDuongKHLL.DataBind();
            droDuongKHTT.DataSource = dtt.DS();
            droDuongKHTT.DataBind();
            droXaKHLL.DataSource = xpll.DS("0000");
            droXaKHLL.DataBind();
            droXaKHTT.DataSource = xptt.DS("0000");
            droXaKHTT.DataBind();
            droHuyenKHLL.DataSource = hll.DS_TheoTinh("00");
            droHuyenKHLL.DataBind();
            droHuyenKHTT.DataSource = htt.DS_TheoTinh("00");
            droHuyenKHTT.DataBind();
            droTinhKHLL.DataSource = tll.DS();
            droTinhKHLL.DataBind();
            droTinhKHTT.DataSource = ttt.DS();
            droTinhKHTT.DataBind();
        }
    }
    protected void griKhachHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griKhachHang.PageIndex = e.NewPageIndex;
        if (Session["MaNPPClick"] == null)
            griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));
        else
            griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPPClick"].ToString(), bool.Parse(Session["Loai"].ToString()));
        griKhachHang.DataBind();
    }
    protected void griKhachHang_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietKH.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtNgayKyThe.Visible = true;
        if (Session["MaNPPClick"] == null)
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnTroThanhNPP.Visible = true;
            lbtSP.Visible = true;
            lbtCTSDR.Visible = true;
        }
        lbtThemMoi.Visible = false;
        kh.MaKH = griKhachHang.SelectedValue.ToString();
        kh.CT();
        txtMaKH.Text = kh.MaKH;
        txtMaKH.Enabled = true;
        txtHoKH.Text = kh.HoKH;
        txtTenKH.Text = kh.TenKH;
        //txtNgaySinh.Text = kh.NgaySinh;
        string temp1 = kh.NgaySinh.ToString().Replace("12:00:00 AM", "");
        txtNgaySinh.Text = temp1;
        txtNgaySinh.Enabled = false;
        if (kh.GioiTinh == true)
        {
            rdoNam.Checked = true;
        }
        else
            rdoNu.Checked = true;
        txtCMND.Text = kh.CMND;
        txtSoDT.Text = kh.SoDT;
        txtEmail.Text = kh.Email;
        chkLoai.Checked = kh.Loai;
        txtSoNhaKHTT.Text = kh.SoNhaKHTT;
        txtSoNhaKHLL.Text = kh.SoNhaKHLL;
        //Tinh
        tll.MaTinh = kh.MaTinhKHLL;
        droTinhKHLL.SelectedValue = tll.MaTinh.ToString();
        ttt.MaTinh = kh.MaTinhKHTT;
        droTinhKHTT.SelectedValue = ttt.MaTinh.ToString();
        //Huyen
        droTinhKHLL_SelectedIndexChanged(sender, e);
        //droHuyenKHLL.DataSource = hll.DS_TheoTinh(tll.MaTinh);
        // droHuyenKHLL.DataBind();           
        droTinhKHTT_SelectedIndexChanged(sender, e);
        //droHuyenKHTT.DataSource = htt.DS_TheoTinh(ttt.MaTinh);
        //droHuyenKHTT.DataBind();
        hll.MaHuyen = kh.MaHuyenKHLL;
        droHuyenKHLL.SelectedValue = hll.MaHuyen.ToString();
        htt.MaHuyen = kh.MaHuyenKHTT;
        droHuyenKHTT.SelectedValue = htt.MaHuyen.ToString();
        //Xa
        droHuyenKHLL_SelectedIndexChanged(sender, e);
        //droXaKHLL.DataSource = xpll.DS(hll.MaHuyen);
        //droXaKHLL.DataBind();
        droHuyenKHTT_SelectedIndexChanged(sender, e);
        //droXaKHTT.DataSource = xptt.DS(htt.MaHuyen);
        //droXaKHTT.DataBind();
        xpll.MaXa = kh.MaXaKHLL;
        droXaKHLL.SelectedValue = xpll.MaXa.ToString();
        xptt.MaXa = kh.MaXaKHTT;
        droXaKHTT.SelectedValue = xptt.MaXa.ToString();
        //Duong
        dll.MaDuong = kh.MaDuongKHLL;
        droDuongKHLL.SelectedValue = dll.MaDuong.ToString();
        dtt.MaDuong = kh.MaDuongKHTT;
        droDuongKHTT.SelectedValue = dtt.MaDuong.ToString();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
        // Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietKH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        btnTroThanhNPP.Visible = false;
        lblTB.Visible = false;
        txtMaKH.Text = "";
        lblMaNPP.Visible = false;
        txtMaNPP.Visible = false;
        txtNgayKyThe.Visible = false;
        txtHoKH.Text = "";
        txtTenKH.Text = "";
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtSoNhaKHTT.Text = "";
        txtSoNhaKHLL.Text = "";
        droDuongKHLL.SelectedValue = "0000";
        droDuongKHTT.SelectedValue = "0000";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bHoKH = string.IsNullOrWhiteSpace(txtHoKH.Text);
        bool bTenKH = string.IsNullOrWhiteSpace(txtTenKH.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        if (bHoKH == false && bTenKH == false && bNgaySinh == false && bSoDT == false)
        {
            kh.HoKH = txtHoKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.NgaySinh = txtNgaySinh.Text;
            if (rdoNam.Checked == true)
                kh.GioiTinh = true;
            else
                kh.GioiTinh = false; 
            kh.CMND = txtCMND.Text;
            kh.SoDT = txtSoDT.Text;
            kh.Email = txtEmail.Text;
            kh.SoNhaKHTT = txtSoNhaKHTT.Text;
            kh.SoNhaKHLL = txtSoNhaKHLL.Text;
            kh.MaDuongKHTT = droDuongKHTT.SelectedValue;
            kh.MaDuongKHLL = droDuongKHLL.SelectedValue;
            kh.MaXaKHTT = droXaKHTT.SelectedValue;
            kh.MaXaKHLL = droXaKHLL.SelectedValue;
            kh.Them();
            lblTB.Visible = true;
            lblTB.Text = kh.ThongBao;
            griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));
            griKhachHang.DataBind();
            pnlChiTietKH.Visible = false;
            lbtThemMoi.Visible = true;//nếu thông báo là khách hàng này đã tồn tại thì không cho response, làm sao để lấy mã khách hàng vừa thêm thành công đến cho trang sản phẩm nếu sử dụng. Session["MaKH"] = griKhachHang.SelectedValue.ToString();
            kh.Tim_MaKH();
            lblTBKH.Visible = true;
            lblTBKH.Text = kh.MaKH;
            if (kh.MaKH != null)
            {
                Session["MaKH"] = kh.MaKH;
                Response.Redirect("~/User/SanPham_GoiY.aspx");
            }
        }
        else
        {
                lblTB.Visible = true;
                lblTB.Text = "Ở các vị trí * bắt buộc bạn phải nhập.";
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        kh.MaKH = griKhachHang.SelectedValue.ToString();
        khsd.MaKH = kh.MaKH;
        khsd.Xoa_DS();
        cs.MaKH = kh.MaKH;
        cs.Xoa_DS();
        kh.Xoa();
        griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));
        griKhachHang.DataBind();
        lblTB.Visible = true;
        lblTB.Text = kh.ThongBao;
        txtMaKH.Text = "";
        txtHoKH.Text = "";
        txtTenKH.Text = "";
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        chkLoai.Checked = false;
        txtSoNhaKHTT.Text = "";
        txtSoNhaKHLL.Text = "";
        pnlChiTietKH.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bHoKH = string.IsNullOrWhiteSpace(txtHoKH.Text);
        bool bTenKH = string.IsNullOrWhiteSpace(txtTenKH.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        if (bHoKH == false && bTenKH == false && bNgaySinh == false && bSoDT == false)
        {
            kh.MaKH = griKhachHang.SelectedValue.ToString();
            kh.HoKH = txtHoKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.NgaySinh = txtNgaySinh.Text;
            if(rdoNam.Checked == true)
                kh.GioiTinh = true;
            else
                kh.GioiTinh = false;
            kh.CMND = txtCMND.Text;
            kh.SoDT = txtSoDT.Text;
            kh.Email = txtEmail.Text;
            if (chkLoai.Checked == false)
                kh.Loai = false;
            else
                kh.Loai = true;
            kh.SoNhaKHTT = txtSoNhaKHTT.Text;
            kh.SoNhaKHLL = txtSoNhaKHLL.Text;
            kh.MaDuongKHTT = droDuongKHTT.SelectedValue;
            kh.MaDuongKHLL = droDuongKHLL.SelectedValue;
            kh.MaXaKHTT = droXaKHTT.SelectedValue;
            kh.MaXaKHLL = droXaKHLL.SelectedValue;
            kh.MaHuyenKHTT = droHuyenKHTT.SelectedValue;
            kh.MaHuyenKHLL = droHuyenKHLL.SelectedValue;
            kh.MaTinhKHTT = droTinhKHTT.SelectedValue;
            kh.MaTinhKHLL = droTinhKHLL.SelectedValue;
            kh.Sua();
            lblTB.Visible = true;
            lblTB.Text = kh.ThongBao;
            griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));
            griKhachHang.DataBind();
            pnlChiTietKH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Các vị trí * là bắt buộc bạn nhập.";
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietKH.Visible = false;
        if (Session["MaNPPClick"] == null)
            lbtThemMoi.Visible = true;
        else
            lbtThemMoi.Visible = false;
        lblTB.Visible = false;
    }
    protected void btnTroThanhNPP_Click(object sender, EventArgs e)
    {
        bool bMaNPP = string.IsNullOrWhiteSpace(txtMaNPP.Text);
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoKH.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenKH.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        bool bNgayKyThe = string.IsNullOrWhiteSpace(txtNgayKyThe.Text);
        if (bMaNPP == false && bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && bNgayKyThe == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = txtMaNPP.Text;
            npp.HoNPP = txtHoKH.Text;
            npp.TenNPP = txtTenKH.Text;
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
            npp.SoNhaNPPTT = txtSoNhaKHTT.Text;
            npp.SoNhaNPPLL = txtSoNhaKHLL.Text;
            npp.MaCD = 0;
            npp.MaDuongNPPTT = droDuongKHTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongKHLL.SelectedValue;
            npp.MaXaNPPTT = droXaKHTT.SelectedValue;
            npp.MaXaNPPLL = droXaKHLL.SelectedValue;
            npp.MaNBT = Session["MaNPP"].ToString();//mã người đang login hoặc click, chuyển Chăm sóc thành đào tạo, xóa chăm sóc, chuyển khsd thành nppsd, xóa khsd.
            npp.Them();// nếu thành công mới làm những cái dưới.
            npp.MaNPP = "1";
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            npp.Tim_MaNPP();
            if (npp.MaNPP == txtMaNPP.Text)
            {
                kh.MaKH = griKhachHang.SelectedValue.ToString();
                while (cs.SL_ChamSoc(kh.MaKH) > 0)
                {
                    cs.DS_KH(kh.MaKH);
                    cs.CT();
                    dt.MaCT = cs.MaCT;
                    dt.NgayDT = cs.NgayCS;
                    dt.MaNPP = txtMaNPP.ToString();
                    dt.Them();
                    cs.Xoa();
                };
                while (khsd.SL_KHSuDung(kh.MaKH) > 0)
                {
                    khsd.DS_KH(kh.MaKH);
                    khsd.CT();
                    nppsd.MaMH = khsd.MaMH;
                    nppsd.MaNPP = txtMaNPP.ToString();
                    nppsd.NgayNPPSD = khsd.NgayKHSD;
                    nppsd.SoLuong = khsd.SoLuong;
                    nppsd.MinhHoa = khsd.MinhHoa;
                    nppsd.NgayNPPSDHH = khsd.NgayKHSDHH;
                    nppsd.GhiChu = khsd.GhiChu;
                    nppsd.Them();
                    khsd.Xoa();
                };
                kh.MaKH = griKhachHang.SelectedValue.ToString();
                kh.Xoa();
                txtMaKH.Text = "";
                txtMaNPP.Text = "";
                txtHoKH.Text = "";
                txtTenKH.Text = "";
                txtNgaySinh.Text = "";
                txtCMND.Text = "";
                txtSoDT.Text = "";
                txtEmail.Text = "";
                txtNgayKyThe.Text = "";
                txtSoNhaKHTT.Text = "";
                txtSoNhaKHLL.Text = "";
                lblTBKH.Visible = true;
                lblTBKH.Text = kh.ThongBao;
                griKhachHang.DataSource = kh.KhachHang_DS_TheoLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));
                griKhachHang.DataBind();
                pnlChiTietKH.Visible = false;
                lbtThemMoi.Visible = true;
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
    protected void lbtSPSD_Click(object sender, EventArgs e)
    {
        Session["MaKH"] = griKhachHang.SelectedValue.ToString();
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/SanPham_DaDung.aspx?MaKH=" + Session["MaKH"] + "&MaADA=" + Session["MaNPPClick"]);
            else
                Response.Redirect("~/User/SanPham_DaDung.aspx?MaKH=" + Session["MaKH"]);
    }
    protected void lbtTTCS_Click(object sender, EventArgs e)
    {
        Session["MaKH"] = griKhachHang.SelectedValue.ToString();
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/ChuongTrinh_ChamSoc.aspx?MaKH=" + Session["MaKH"] + "&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/ChuongTrinh_ChamSoc.aspx?MaKH=" + Session["MaKH"]);
    }
    protected void lbtSP_Click(object sender, EventArgs e)
    {
        Session["MaKH"] = griKhachHang.SelectedValue.ToString();
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        Session["MaLMH"] = "0";
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/SanPham.aspx?MaKH=" + Session["MaKH"] + "MaLMH=0" + "&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/SanPham.aspx?MaKH=" + Session["MaKH"] + "MaLMH=0");
    }
    protected void lbtSPGY_Click(object sender, EventArgs e)
    {
        Session["MaKH"] = griKhachHang.SelectedValue.ToString();
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/SanPham_GoiY.aspx?MaKH=" + Session["MaKH"] + "&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/SanPham_GoiY.aspx?MaKH=" + Session["MaKH"]);
    }
    protected void lbtCTSDR_Click(object sender, EventArgs e)
    {
        Session["MaKH"] = griKhachHang.SelectedValue.ToString();
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] != null)
            Response.Redirect("~/User/ChuongTrinh_SapDienRa.aspx?MaKH=" + Session["MaKH"] + "&MaADA=" + Session["MaNPPClick"]);
        else
            Response.Redirect("~/User/ChuongTrinh_SapDienRa.aspx?MaKH=" + Session["MaKH"]);
    }
    protected void droTinhKHLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        kh.MaTinhKHLL = droTinhKHLL.SelectedValue;
        droHuyenKHLL.DataSource = hll.DS_TheoTinh(kh.MaTinhKHLL);
        droHuyenKHLL.DataBind();
    }
    protected void droHuyenKHLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        kh.MaHuyenKHLL = droHuyenKHLL.SelectedValue;
        droXaKHLL.DataSource = xpll.DS(kh.MaHuyenKHLL);
        droXaKHLL.DataBind();
    }
    protected void droTinhKHTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        kh.MaTinhKHTT = droTinhKHTT.SelectedValue;
        droHuyenKHTT.DataSource = htt.DS_TheoTinh(kh.MaTinhKHTT);
        droHuyenKHTT.DataBind();
    }
    protected void droHuyenKHTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        kh.MaHuyenKHTT = droHuyenKHTT.SelectedValue;
        droXaKHTT.DataSource = xptt.DS(kh.MaHuyenKHTT);
        droXaKHTT.DataBind();
    }
}