using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham_ChuaDung : System.Web.UI.Page
{
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.LoaiMH lmh = new webdoan.LoaiMH();
    webdoan.MatHang mh = new webdoan.MatHang();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
        {
            griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());
            griMatHangChuaDung.DataBind();
        }
        else
        {
            griMatHangChuaDung.DataSource = khsd.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griMatHangChuaDung.DataBind();
        }
        droLoaiMH.DataSource = lmh.DS();
        droLoaiMH.DataBind();
    }
    protected void griMatHangChuaDung_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = true;
        btnSuDung.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        if (Session["MaKH"].ToString() == null)
        {
            nppsd.MaMH = griMatHangChuaDung.SelectedValue.ToString();
            nppsd.CT();
            txtMaMH.Text = nppsd.MaMH.ToString();
            txtMaMH.ReadOnly = true;
            txtTenMH.Text = nppsd.TenMH;
            txtGia.Text = nppsd.Gia.ToString();
            txtChiTiet.Text = nppsd.ChiTiet;
            //fckChiTiet.Text = mh.ChiTiet;
            txtCachSuDung.Text = nppsd.CachSuDung.ToString();
            imgAnhMH.ImageUrl = "~/src/product/" + nppsd.AnhMH;
            lmh.MaLMH = nppsd.MaLMH;
            droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
        }
        else
        {
            khsd.MaMH = griMatHangChuaDung.SelectedValue.ToString();
            khsd.CT();
            txtMaMH.Text = khsd.MaMH.ToString();
            txtMaMH.ReadOnly = true;
            txtTenMH.Text = khsd.TenMH;
            txtGia.Text = khsd.Gia.ToString();
            txtChiTiet.Text = khsd.ChiTiet;
            //fckChiTiet.Text = mh.ChiTiet;
            txtCachSuDung.Text = khsd.CachSuDung.ToString();
            imgAnhMH.ImageUrl = "~/src/product/" + khsd.AnhMH;
            lmh.MaLMH = khsd.MaLMH;
            droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
        }
    }
    protected void griMatHangChuaDung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHangChuaDung.PageIndex = e.NewPageIndex;
        if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
        {
            griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());
            griMatHangChuaDung.DataBind();
        }
        else
        {
            griMatHangChuaDung.DataSource = khsd.MatHang_ChuaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
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
        if (Session["MaKH"].ToString() == null)//???nếu không chọn khách hàng thì sử dụng này là nhà phân phối sử dụng
        {
            nppsd.MaMH = griMatHangChuaDung.SelectedValue.ToString();
            nppsd.MaNPP = Session["MaNPP"].ToString();
            nppsd.ThoiGian = txtThoiGian.Text;
            nppsd.SoLuong = int.Parse(txtSoLuong.Text);
            if (chkMinhHoa.Checked == true)
                nppsd.MinhHoa = true;
            else
                nppsd.MinhHoa = false;
            nppsd.Them();
            lblTB.Visible = true;
            lblTB.Text = nppsd.ThongBao;
        }
        else
        {
            khsd.MaMH = griMatHangChuaDung.SelectedValue.ToString();
            khsd.MaKH = Session["MaKH"].ToString();
            khsd.MaNPP = Session["MaNPP"].ToString();
            khsd.ThoiGian = txtThoiGian.Text;
            khsd.SoLuong = int.Parse(txtSoLuong.Text);
            if (chkMinhHoa.Checked == true)
                khsd.MinhHoa = true;
            else
                khsd.MinhHoa = false;
            khsd.Them();
            lblTB.Visible = true;
            lblTB.Text = khsd.ThongBao;
        }
        txtSoLuong.Visible = false;
        chkMinhHoa.Visible = false;
    }
}