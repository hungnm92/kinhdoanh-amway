using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham_DaDung : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.KhachHang kh = new webdoan.KhachHang();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.LoaiSP lsp = new webdoan.LoaiSP();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaNPP"] == null)
            Response.Redirect("~/DangNhap.aspx");
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaKH"] == null)
        {
            if (Session["MaNPPClick"] == null)
                griMatHangNPPDaDung.DataSource = nppsd.SanPham_DaDung(Session["MaNPP"].ToString());
            else
            {
                griMatHangNPPDaDung.DataSource = nppsd.SanPham_DaDung(Session["MaNPPClick"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem sản phẩm sử dụng của: " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
            }
            griMatHangNPPDaDung.DataBind();
            griMatHangKHDaDung.Visible = false;
        }
        else
        {
            if (Session["MaNPPClick"] == null)
            {
                griMatHangKHDaDung.DataSource = khsd.SanPham_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem sản phẩm sử dụng của khách hàng: " + kh.HoKH + " " + kh.TenKH;
                lbtTroVe.Visible = true;
            }
            else
            {
                griMatHangKHDaDung.DataSource = khsd.SanPham_DaDung(Session["MaNPPClick"].ToString(), Session["MaKH"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem sản phẩm sử dụng của "+kh.HoKH+" "+kh.TenKH+" là khách hàng "+npp.HoNPP+ " "+npp.TenNPP;
                lbtTroVe.Visible = true;
            }
            griMatHangKHDaDung.DataBind();
            griMatHangNPPDaDung.Visible = false;
        }
        droLoaiMH.DataSource = lsp.DS();
        droLoaiMH.DataBind();
    }
    protected void griMatHangDaDung_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        if (Session["MaNPPClick"] == null)
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        if (Session["MaKH"] == null)
        {
            nppsd.MaNPPSD = griMatHangNPPDaDung.SelectedValue.ToString();
            nppsd.CT();
            txtMaSP.Text = nppsd.MaSP.ToString();
            txtMaSP.ReadOnly = true;
            txtTenSP.Text = nppsd.TenSP;
            txtGia.Text = nppsd.Gia.ToString();
            fckChiTiet.Text = nppsd.ChiTiet;
            txtCachSuDung.Text = nppsd.CachSuDung.ToString();
            txtSoLuong.Text = nppsd.SoLuong.ToString();
            txtTongTien.Text = (float.Parse(txtGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
            if (chkMinhHoa.Checked == true)
                nppsd.MinhHoa = true;
            else
                nppsd.MinhHoa = false;
            imgAnhSP.ImageUrl = "~/src/product/" + nppsd.AnhSP;
            lsp.MaLSP = nppsd.MaLSP;
            droLoaiMH.SelectedValue = lsp.MaLSP.ToString();
            //txtThoiGian.Text = nppsd.NgayNPPSD;
            string temp1 = nppsd.NgayNPPSD.ToString().Replace(" 12:00:00 AM", "");
            temp1 = temp1.Substring(8, 2) + "/" + temp1.Substring(5, 2) + "/" + temp1.Substring(0, 4);
            txtThoiGian.Text = temp1;
            if (nppsd.NgayNPPSDHH.ToString() == DBNull.Value.ToString())
                txtNgayHH.Text = "";
            else
            {
                //txtNgayHH.Text = nppsd.NgayNPPSDHH;
                string temp2 = nppsd.NgayNPPSDHH.ToString().Replace(" 12:00:00 AM", "");
                temp2 = temp2.Substring(8, 2) + "/" + temp2.Substring(5, 2) + "/" + temp2.Substring(0, 4);
                txtNgayHH.Text = temp2;
                txtGhiChu.Text = nppsd.GhiChu;
            }
        }
        else
        {
            khsd.MaKHSD = griMatHangKHDaDung.SelectedValue.ToString();
            khsd.CT();
            txtMaSP.Text = khsd.MaSP.ToString();
            txtMaSP.ReadOnly = true;
            txtTenSP.Text = khsd.TenSP;
            txtGia.Text = khsd.Gia.ToString();
            fckChiTiet.Text = khsd.ChiTiet;
            txtCachSuDung.Text = khsd.CachSuDung.ToString();
            txtSoLuong.Text = khsd.SoLuong.ToString();
            txtTongTien.Text = ((0.15 * float.Parse(txtGia.Text) + float.Parse(txtGia.Text)) * int.Parse(txtSoLuong.Text)).ToString();
            if (chkMinhHoa.Checked == true)
                khsd.MinhHoa = true;
            else
                khsd.MinhHoa = false;
            imgAnhSP.ImageUrl = "~/src/product/" + khsd.AnhSP;
            lsp.MaLSP = khsd.MaLSP;
            droLoaiMH.SelectedValue = lsp.MaLSP.ToString();
            //txtThoiGian.Text = khsd.NgayKHSD;
            string temp3 = khsd.NgayKHSD.ToString().Replace(" 12:00:00 AM", "");
            temp3 = temp3.Substring(8, 2) + "/" + temp3.Substring(5, 2) + "/" + temp3.Substring(0, 4);
            txtThoiGian.Text = temp3;
            if (khsd.NgayKHSDHH.ToString() == DBNull.Value.ToString())
                txtNgayHH.Text = "";
            else
            {
                //txtNgayHH.Text = khsd.NgayKHSDHH;
                string temp4 = khsd.NgayKHSDHH.ToString().Replace(" 12:00:00 AM", "");
                temp4 = temp4.Substring(8, 2) + "/" + temp4.Substring(5, 2) + "/" + temp4.Substring(0, 4);
                txtNgayHH.Text = temp4;
                txtGhiChu.Text = khsd.GhiChu;
            }
        }       
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if (Session["MaKH"] == null)
        {
            nppsd.MaNPPSD = griMatHangNPPDaDung.SelectedValue.ToString();
            nppsd.Xoa();
            lblTB.Visible = true;
            lblTB.Text = nppsd.ThongBao;
            griMatHangNPPDaDung.DataSource = nppsd.SanPham_DaDung(Session["MaNPP"].ToString());
            griMatHangNPPDaDung.DataBind();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";
            fckChiTiet.Text = "";
            txtCachSuDung.Text = "";
            pnlChiTietMH.Visible = false;
            txtThoiGian.Text = "";
            txtNgayHH.Text = "";
            txtGhiChu.Text = "";
        }
        else
        {
            khsd.MaKHSD = griMatHangKHDaDung.SelectedValue.ToString();
            khsd.Xoa();
            lblTB.Visible = true;
            lblTB.Text = khsd.ThongBao;
            griMatHangKHDaDung.DataSource = khsd.SanPham_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griMatHangKHDaDung.DataBind();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";
            fckChiTiet.Text = "";
            txtCachSuDung.Text = "";
            pnlChiTietMH.Visible = false;
            txtThoiGian.Text = "";
            txtNgayHH.Text = "";
            txtGhiChu.Text = "";
        }
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bSoLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text);
        if (bSoLuong == false)
        {
            if (Session["MaKH"] == null)
            {
                nppsd.SoLuong = int.Parse(txtSoLuong.Text);
                if (chkMinhHoa.Checked == true)
                    nppsd.MinhHoa = true;
                else
                    nppsd.MinhHoa = false;
                nppsd.NgayNPPSDHH = txtNgayHH.Text;
                nppsd.GhiChu = txtGhiChu.Text;
                nppsd.MaNPPSD = griMatHangNPPDaDung.SelectedValue.ToString();
                nppsd.Sua();
                griMatHangNPPDaDung.DataSource = nppsd.SanPham_DaDung(Session["MaNPP"].ToString());
                griMatHangNPPDaDung.DataBind();
                lblTB.Visible = true;
                lblTB.Text = nppsd.ThongBao;
            }
            else
            {
                khsd.SoLuong = int.Parse(txtSoLuong.Text);
                if (chkMinhHoa.Checked == true)
                    khsd.MinhHoa = true;
                else
                    khsd.MinhHoa = false;
                khsd.NgayKHSDHH = txtNgayHH.Text;
                khsd.GhiChu = txtGhiChu.Text;
                khsd.MaKHSD = griMatHangKHDaDung.SelectedValue.ToString();
                khsd.Sua();
                griMatHangKHDaDung.DataSource = khsd.SanPham_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
                griMatHangKHDaDung.DataBind();
                lblTB.Visible = true;
                lblTB.Text = khsd.ThongBao;
            }
            pnlChiTietMH.Visible = false;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Chưa có số lượng.";
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = false;
        lblTB.Visible = false;
    }
    protected void griMatHangDaDung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["MaKH"] == null)
        {
            griMatHangNPPDaDung.PageIndex = e.NewPageIndex;
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
                griMatHangNPPDaDung.DataSource = nppsd.SanPham_DaDung(Session["MaNPP"].ToString());
            else
                griMatHangNPPDaDung.DataSource = nppsd.SanPham_DaDung(Session["MaNPPClick"].ToString());
            griMatHangNPPDaDung.DataBind();
            griMatHangKHDaDung.Visible = false;
        }
        else
        {
            griMatHangKHDaDung.PageIndex = e.NewPageIndex;
            if (Session["MaNPPClick"] == null)
                griMatHangKHDaDung.DataSource = khsd.SanPham_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            else
                griMatHangKHDaDung.DataSource = khsd.SanPham_DaDung(Session["MaNPPClick"].ToString(), Session["MaKH"].ToString());
            griMatHangKHDaDung.DataBind();
            griMatHangNPPDaDung.Visible = false;
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
    protected void txtGia_TextChanged(object sender, EventArgs e)
    {
        if(Session["MaKH"] == null)
            txtTongTien.Text = (float.Parse(txtGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
        else
            txtTongTien.Text = ((0.15 * float.Parse(txtGia.Text) + float.Parse(txtGia.Text)) * int.Parse(txtSoLuong.Text)).ToString();
    }
    protected void txtSoLuong_TextChanged(object sender, EventArgs e)
    {
        if (Session["MaKH"] == null)
            txtTongTien.Text = (float.Parse(txtGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
        else
            txtTongTien.Text = ((0.15 * float.Parse(txtGia.Text) + float.Parse(txtGia.Text)) * int.Parse(txtSoLuong.Text)).ToString();
    }
}