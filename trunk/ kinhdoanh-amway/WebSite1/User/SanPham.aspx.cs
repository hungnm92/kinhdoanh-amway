using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham : System.Web.UI.Page
{
    webdoan.KhachHang kh = new webdoan.KhachHang();
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.SanPham sp = new webdoan.SanPham();
    webdoan.LoaiSP lsp = new webdoan.LoaiSP();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["MaLSP"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if(Session["MaLSP"] == "0")
                griMatHang.DataSource = sp.DS();
            else
                griMatHang.DataSource = sp.SanPham_DS_TheoLoaiSP(int.Parse(Session["MaLSP"].ToString()));
            griMatHang.DataBind();
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaKH"] == null)
            {
                if (Session["MaNPPClick"] == null || Session["MaNPP"].ToString() == "0000000")
                {
                    lbtThemMoi.Visible = true;
                }
                else
                {
                    npp.MaNPP = Session["MaNPPClick"].ToString();
                    npp.CT();
                    lblClick.Visible = true;
                    lblClick.Text = "Bạn đang xem sản phẩm của: " + npp.HoNPP + " " + npp.TenNPP;
                    lbtThemMoi.Visible = false;
                    lbtTroVe.Visible = true;
                }
            }
            else
            {
                if (Session["MaNPPClick"] == null)
                {
                    kh.MaKH = Session["MaKH"].ToString();
                    kh.CT();
                    lblClick.Visible = true;
                    lblClick.Text = "Bạn đang xem sản phẩm sử dụng của khách hàng: " + kh.HoKH + " " + kh.TenKH;
                    lbtTroVe.Visible = true;
                    lbtThemMoi.Visible = false;
                }
                else
                {
                    npp.MaNPP = Session["MaNPPClick"].ToString();
                    npp.CT();
                    kh.MaKH = Session["MaKH"].ToString();
                    kh.CT();
                    lblClick.Visible = true;
                    lblClick.Text = "Bạn đang xem sản phẩm của " + kh.HoKH + " " + kh.TenKH + " là khách hàng " + npp.HoNPP + " " + npp.TenNPP;
                    lbtTroVe.Visible = true;
                    lbtThemMoi.Visible = false;
                }
            }
            droLoaiSP.DataSource = lsp.DS();
            droLoaiSP.DataBind();
        }
    }
    protected void griMatHang_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        if ((Session["MaNPPClick"] == null && Session["MaKH"] == null) || Session["MaNPP"].ToString() == "0000000")
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        if (Session["MaNPPClick"] == null)
        {
            btnSuDung.Visible = true;
            txtSoLuong.Visible = true;
            chkMinhHoa.Visible = true;
            txtNgaySD.Visible = true;
            txtNgayHH.Visible = true;
            txtGhiChu.Visible = true;
        }
        btnThoat.Visible = true;
        lblTB.Visible = false;
        sp.MaSP = griMatHang.SelectedValue.ToString();
        sp.CT();
        txtMaSP.Text = sp.MaSP.ToString();
        txtMaSP.Enabled = false;
        txtTenSP.Text = sp.TenSP;
        txtGia.Text = sp.Gia.ToString();
        imgAnhSP.ImageUrl = "~/src/product/" + sp.AnhSP;
        fckChiTiet.Text = sp.ChiTiet;
        txtCachSuDung.Text = sp.CachSuDung.ToString();
        lsp.MaLSP = sp.MaLSP;
        droLoaiSP.SelectedValue = lsp.MaLSP.ToString();
    }
    protected void griMatHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHang.PageIndex = e.NewPageIndex;
        if (Session["MaLSP"] == "0")
            griMatHang.DataSource = sp.DS();
        else
            griMatHang.DataSource = sp.SanPham_DS_TheoLoaiSP(int.Parse(Session["MaLSP"].ToString()));
        griMatHang.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
        //Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietMH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        txtMaSP.Enabled = true;
        txtMaSP.ReadOnly = false;
        btnSuDung.Visible = false;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtSoLuong.Visible = false;
        chkMinhHoa.Visible = false;
        txtMaSP.Text = "";
        txtTenSP.Text = "";
        txtGia.Text = "";
        fckChiTiet.Text = "";
        txtCachSuDung.Text = "";
        imgAnhSP.ImageUrl = "~/src/product/";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaSP = string.IsNullOrWhiteSpace(txtMaSP.Text);
        bool bTenSP = string.IsNullOrWhiteSpace(txtTenSP.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        if (bTenSP == false && bGia == false && fileAnhSP.HasFile == true)
        {
            sp.MaSP = txtMaSP.Text;
            sp.TenSP = txtTenSP.Text;
            string DuongDan = "";
            string ReName = txtMaSP.Text;
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhSP.SaveAs(DuongDan);
            sp.AnhSP = ReName + ".jpg";
            sp.ChiTiet = fckChiTiet.Text;
            sp.CachSuDung = txtCachSuDung.Text;
            sp.Gia = float.Parse(txtGia.Text);
            sp.MaLSP = int.Parse(Session["MaLSP"].ToString());
            sp.Them();
            lblTB.Visible = true;
            lblTB.Text = sp.ThongBao;
            griMatHang.DataSource = sp.SanPham_DS_TheoLoaiSP(int.Parse(Session["MaLSP"].ToString()));
            griMatHang.DataBind();
            pnlChiTietMH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            if (fileAnhSP.HasFile == false)
            {
                lblTB.Visible = true;
                lblTB.Text = "Bạn phải chọn ảnh sản phẩm.";
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
        sp.MaSP = griMatHang.SelectedValue.ToString();
        sp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = sp.ThongBao;
        griMatHang.DataSource = sp.SanPham_DS_TheoLoaiSP(int.Parse(Session["MaLSP"].ToString()));
        griMatHang.DataBind();
        txtMaSP.Text = "";
        txtTenSP.Text = "";
        txtGia.Text = "";
        fckChiTiet.Text = "";
        txtCachSuDung.Text = "";      
        pnlChiTietMH.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bTenSP = string.IsNullOrWhiteSpace(txtTenSP.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        bool bCachSuDung = string.IsNullOrWhiteSpace(txtCachSuDung.Text);
        bool bChiTiet = string.IsNullOrWhiteSpace(fckChiTiet.Text);
        if (bTenSP == false && bGia == false && bCachSuDung == false && bChiTiet == false && fileAnhSP.HasFile == true)
        {
            sp.MaSP = griMatHang.SelectedValue.ToString();
            sp.TenSP = txtTenSP.Text;
            string DuongDan = "";
            string ReName = txtMaSP.Text;
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhSP.SaveAs(DuongDan);
            sp.AnhSP = ReName + ".jpg";
            sp.Gia = double.Parse(txtGia.Text);
            sp.CachSuDung = txtCachSuDung.Text;
            sp.ChiTiet = fckChiTiet.Text;
            sp.MaLSP = int.Parse(droLoaiSP.SelectedValue);
            sp.Sua();
            lblTB.Visible = true;
            lblTB.Text = sp.ThongBao;
            griMatHang.DataSource = sp.SanPham_DS_TheoLoaiSP(int.Parse(Session["MaLSP"].ToString()));
            griMatHang.DataBind();
            pnlChiTietMH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
            if (bTenSP == false && bGia == false && bCachSuDung == false && bChiTiet == false && fileAnhSP.HasFile == false)
            {
                sp.MaSP = griMatHang.SelectedValue.ToString();
                sp.CT();
                string temp = sp.AnhSP.ToString();
                sp.TenSP = txtTenSP.Text;
                sp.AnhSP = temp;
                sp.Gia = double.Parse(txtGia.Text);
                sp.CachSuDung = txtCachSuDung.Text;
                sp.ChiTiet = fckChiTiet.Text;
                sp.MaLSP = int.Parse(droLoaiSP.SelectedValue);
                sp.Sua();
                lblTB.Visible = true;
                lblTB.Text = sp.ThongBao;
                griMatHang.DataSource = sp.SanPham_DS_TheoLoaiSP(int.Parse(Session["MaLSP"].ToString()));
                griMatHang.DataBind();
                pnlChiTietMH.Visible = false;
                lbtThemMoi.Visible = true;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Các vị trí * là bắt buộc nhập.";
            }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = false;
        if (Session["MaNPPClick"] == null && Session["MaKH"] == null)
            lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnSuDung_Click(object sender, EventArgs e)
    {
        txtSoLuong.Visible = true;
        chkMinhHoa.Visible = true;
        txtNgaySD.Visible = true;
        txtNgayHH.Visible = true;
        txtGhiChu.Visible = true;
        bool bSoLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text);
        bool bNgaySD = string.IsNullOrWhiteSpace(txtNgaySD.Text);
        if (bSoLuong == false && bNgaySD == false)
        {
            if (Session["MaKH"] == null)//???nếu không chọn khách hàng thì sử dụng này là nhà phân phối sử dụng
            {
                nppsd.MaSP = griMatHang.SelectedValue.ToString();
                nppsd.MaNPP = Session["MaNPP"].ToString();
                nppsd.NgayNPPSD = txtNgaySD.Text;
                if (txtGhiChu.Text == "Ghi chú")
                    nppsd.GhiChu = "";
                else
                    nppsd.GhiChu = txtGhiChu.Text;
                nppsd.SoLuong = int.Parse(txtSoLuong.Text);
                if (chkMinhHoa.Checked == true)
                    nppsd.MinhHoa = true;
                else
                    nppsd.MinhHoa = false;
                if (txtNgayHH.Text == "Ngày hết hạn")
                    nppsd.Them1();
                else
                {
                    nppsd.NgayNPPSDHH = txtNgayHH.Text;
                    nppsd.Them();
                }
                lblTB.Visible = true;
                lblTB.Text = nppsd.ThongBao;
            }
            else
            {
                khsd.MaSP = griMatHang.SelectedValue.ToString();
                khsd.MaKH = Session["MaKH"].ToString();
                khsd.MaNPP = Session["MaNPP"].ToString();
                khsd.NgayKHSD = txtNgaySD.Text;
                if (txtGhiChu.Text == "Ghi chú")
                    khsd.GhiChu = "";
                else
                    khsd.GhiChu = txtGhiChu.Text;
                khsd.SoLuong = int.Parse(txtSoLuong.Text);
                if (chkMinhHoa.Checked == true)
                    khsd.MinhHoa = true;
                else
                    khsd.MinhHoa = false;
                if (txtNgayHH.Text == "Ngày hết hạn")
                    khsd.Them1();
                else
                {
                    khsd.NgayKHSDHH = txtNgayHH.Text;
                    khsd.Them();
                }
                lblTB.Visible = true;
                lblTB.Text = khsd.ThongBao;
            }
            pnlChiTietMH.Visible = false;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Vùi lòng điền thông tin số lượng hoặc ngày sử dụng.";
        }
    }
    protected void lbtTroVe_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["Loai"] != null)
        {
            Session["MaKH"] = null;
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/KhachHang.aspx?Loai=" + Session["Loai"] + "&MaADA=" + Session["MaNPPClick"].ToString());
            else
                Response.Redirect("~/User/KhachHang.aspx?Loai=" + Session["Loai"]);
        }
        else
        {
            if (Session["MaCD"] == null)
                Response.Redirect("~/User/TrangChu.aspx?MaADA=" + Session["MaNPPClick"]);
            else
            {
                if (Session["MaNPPClick"] != null)
                {
                    npp.MaNPP = Session["MaNPPClick"].ToString();
                    npp.CT();
                    Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=" + Session["MaCD"] + "&MaADA=" + npp.MaNBT);
                }
                else
                    Response.Redirect("~/User/NhaPhanPhoi.aspx?MaCD=" + Session["MaCD"]);
            }
        }
    }
}
