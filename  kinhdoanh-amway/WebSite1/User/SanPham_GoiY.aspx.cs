using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham_ChuaDung : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.KhachHang kh = new webdoan.KhachHang();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.LoaiMH lmh = new webdoan.LoaiMH();
    webdoan.MatHang mh = new webdoan.MatHang();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaNPP"] == null)
            Response.Redirect("~/DangNhap.aspx");
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaKH"] == null)
        {
            if (Session["MaNPPClick"] == null)
                griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());
            else
            {
                griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPPClick"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem sản phẩm gợi ý của: " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
            }
            griMatHangChuaDung.DataBind();           
        }
        else
        {
            if (Session["MaNPPClick"] == null)
            {
                griMatHangChuaDung.DataSource = khsd.MatHang_ChuaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem sản phẩm gợi ý của khách hàng: " + kh.HoKH + " " + kh.TenKH;
                lbtTroVe.Visible = true;
            }
            else
            {
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem sản phẩm gợi ý của " + kh.HoKH + " " + kh.TenKH + " là khách hàng " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
                griMatHangChuaDung.DataSource = khsd.MatHang_ChuaDung(Session["MaNPPClick"].ToString(), Session["MaKH"].ToString());
            }
            griMatHangChuaDung.DataBind();
        }
        droLoaiMH.DataSource = lmh.DS();
        droLoaiMH.DataBind();
    }
    protected void griMatHangChuaDung_SelectedIndexChanged(object sender, EventArgs e)
    {
            pnlChiTietMH.Visible = true;
            btnIn.Visible = true;
            btnThoat.Visible = true;
            lblTB.Visible = false;
            if (Session["MaNPPClick"] == null)
            {
                btnSuDung.Visible = true;
                txtSoLuong.Visible = true;
                chkMinhHoa.Visible = true;
                txtNgaySD.Visible = true;
                txtNgayHH.Visible = true;
                txtGhiChu.Visible = true;
            }
            mh.MaMH = griMatHangChuaDung.SelectedValue.ToString();
            mh.CT();
            txtMaMH.Text = mh.MaMH.ToString();
            txtMaMH.ReadOnly = true;
            txtTenMH.Text = mh.TenMH;
            txtGia.Text = mh.Gia.ToString();
            fckChiTiet.Text = mh.ChiTiet;
            txtCachSuDung.Text = mh.CachSuDung.ToString();
            imgAnhMH.ImageUrl = "~/src/product/" + mh.AnhMH;
            lmh.MaLMH = mh.MaLMH;
            droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
    }
    protected void griMatHangChuaDung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHangChuaDung.PageIndex = e.NewPageIndex;
        if (Session["MaKH"] == null)
        {
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
                griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());
            else
                griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPPClick"].ToString());
            griMatHangChuaDung.DataBind();
        }
        else
        {
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
                griMatHangChuaDung.DataSource = khsd.MatHang_ChuaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            else
                griMatHangChuaDung.DataSource = khsd.MatHang_ChuaDung(Session["MaNPPClick"].ToString(), Session["MaKH"].ToString());
            griMatHangChuaDung.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = false;
        lblTB.Visible = false;
    }
    protected void btnSuDung_Click(object sender, EventArgs e)
    {
        txtSoLuong.Visible = true;
        chkMinhHoa.Visible = true;
        txtNgaySD.Visible = true;
        txtNgayHH.Visible = true;
        txtGhiChu.Visible = true;
        if (Session["MaKH"] == null)
        {
            nppsd.MaMH = griMatHangChuaDung.SelectedValue.ToString();
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
            griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());
            griMatHangChuaDung.DataBind();
        }
        else
        {
            khsd.MaMH = griMatHangChuaDung.SelectedValue.ToString();
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
            griMatHangChuaDung.DataSource = khsd.MatHang_ChuaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griMatHangChuaDung.DataBind();
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
    protected void btnIn_Click(object sender, EventArgs e)
    {

    }
}