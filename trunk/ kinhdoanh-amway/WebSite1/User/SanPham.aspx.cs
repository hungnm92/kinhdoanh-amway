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
    webdoan.MatHang mh = new webdoan.MatHang();
    webdoan.LoaiMH lmh = new webdoan.LoaiMH();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["MaLMH"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if(Session["MaLMH"] == "0")
                griMatHang.DataSource = mh.DS();
            else
                griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
            griMatHang.DataBind();
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaKH"] == null)
            {
                if (Session["MaNPPClick"] == null)
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
            droLoaiMH.DataSource = lmh.DS();
            droLoaiMH.DataBind();
        }
    }
    protected void griMatHang_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        if (Session["MaNPPClick"] == null && Session["MaKH"] == null)
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
        mh.MaMH = griMatHang.SelectedValue.ToString();
        mh.CT();
        txtMaMH.Text = mh.MaMH.ToString();
        txtMaMH.Enabled = false;
        txtTenMH.Text = mh.TenMH;
        txtGia.Text = mh.Gia.ToString();
        imgAnhMH.ImageUrl = "~/src/product/" + mh.AnhMH;
        fckChiTiet.Text = mh.ChiTiet;
        txtCachSuDung.Text = mh.CachSuDung.ToString();
        lmh.MaLMH = mh.MaLMH;
        droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
    }
    protected void griMatHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHang.PageIndex = e.NewPageIndex;
        if (Session["MaLMH"] == "0")
            griMatHang.DataSource = mh.DS();
        else
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
        griMatHang.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
        //Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietMH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnSuDung.Visible = false;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtSoLuong.Visible = false;
        chkMinhHoa.Visible = false;
        txtMaMH.Text = "";
        txtTenMH.Text = "";
        txtGia.Text = "";
        fckChiTiet.Text = "";
        txtCachSuDung.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaMH = string.IsNullOrWhiteSpace(txtMaMH.Text);
        bool bTenMH = string.IsNullOrWhiteSpace(txtTenMH.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        if (bTenMH == false && bGia == false && fileAnhMH.HasFile == true)
        {
            mh.MaMH = txtMaMH.Text;
            mh.TenMH = txtTenMH.Text;
            string DuongDan = "";
            string ReName = txtMaMH.Text;
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhMH.SaveAs(DuongDan);
            mh.AnhMH = ReName + ".jpg";
            mh.ChiTiet = fckChiTiet.Text;
            mh.CachSuDung = txtCachSuDung.Text;
            mh.Gia = float.Parse(txtGia.Text);
            mh.MaLMH = int.Parse(Session["MaLMH"].ToString());
            mh.Them();
            lblTB.Visible = true;
            lblTB.Text = mh.ThongBao;
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
            griMatHang.DataBind();
            pnlChiTietMH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            if (fileAnhMH.HasFile == false)
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
        mh.MaMH = griMatHang.SelectedValue.ToString();
        mh.Xoa();
        lblTB.Visible = true;
        lblTB.Text = mh.ThongBao;
        griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
        griMatHang.DataBind();
        txtMaMH.Text = "";
        txtTenMH.Text = "";
        txtGia.Text = "";
        fckChiTiet.Text = "";
        txtCachSuDung.Text = "";      
        pnlChiTietMH.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bTenMH = string.IsNullOrWhiteSpace(txtTenMH.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        bool bCachSuDung = string.IsNullOrWhiteSpace(txtCachSuDung.Text);
        bool bChiTiet = string.IsNullOrWhiteSpace(fckChiTiet.Text);
        if (bTenMH == false && bGia == false && bCachSuDung == false && bChiTiet == false && fileAnhMH.HasFile == true)
        {
            mh.MaMH = griMatHang.SelectedValue.ToString();
            mh.TenMH = txtTenMH.Text;
            string DuongDan = "";
            string ReName = txtMaMH.Text;
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhMH.SaveAs(DuongDan);
            mh.AnhMH = ReName + ".jpg";
            mh.Gia = double.Parse(txtGia.Text);
            mh.CachSuDung = txtCachSuDung.Text;
            mh.ChiTiet = fckChiTiet.Text;
            mh.MaLMH = int.Parse(droLoaiMH.SelectedValue);
            mh.Sua();
            lblTB.Visible = true;
            lblTB.Text = mh.ThongBao;
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
            griMatHang.DataBind();
            pnlChiTietMH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
            if (bTenMH == false && bGia == false && bCachSuDung == false && bChiTiet == false && fileAnhMH.HasFile == false)
            {
                mh.MaMH = griMatHang.SelectedValue.ToString();
                mh.CT();
                string temp = mh.AnhMH.ToString();
                mh.TenMH = txtTenMH.Text;
                mh.AnhMH = temp;
                mh.Gia = double.Parse(txtGia.Text);
                mh.CachSuDung = txtCachSuDung.Text;
                mh.ChiTiet = fckChiTiet.Text;
                mh.MaLMH = int.Parse(droLoaiMH.SelectedValue);
                mh.Sua();
                lblTB.Visible = true;
                lblTB.Text = mh.ThongBao;
                griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
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
        if(Session["MaKH"] == null)//???nếu không chọn khách hàng thì sử dụng này là nhà phân phối sử dụng
        {
            nppsd.MaMH = griMatHang.SelectedValue.ToString();
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
            khsd.MaMH = griMatHang.SelectedValue.ToString();
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
