using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham_DaDung : System.Web.UI.Page
{
    lanhnt.NPPSuDung nppsd = new lanhnt.NPPSuDung();
    lanhnt.KHSuDung khsd = new lanhnt.KHSuDung();
    lanhnt.LoaiMH lmh = new lanhnt.LoaiMH();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
        {
            griMatHangDaDung.DataSource = nppsd.MatHang_DaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
            griMatHangDaDung.DataBind();
        }
        else
        {
            griMatHangDaDung.DataSource = khsd.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griMatHangDaDung.DataBind();
        }
        droLoaiMH.DataSource = lmh.DS();
        droLoaiMH.DataBind();
    }
    protected void griMatHangDaDung_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = true;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        if (Session["MaKH"].ToString() == null)
        {
            nppsd.MaNPPSD = int.Parse(griMatHangDaDung.SelectedValue.ToString());
            nppsd.CT();
            txtMaMH.Text = nppsd.MaMH.ToString();
            txtMaMH.ReadOnly = true;
            txtTenMH.Text = nppsd.TenMH;
            txtGia.Text = nppsd.Gia.ToString();
            txtChiTiet.Text = nppsd.ChiTiet;
            //fckChiTiet.Text = mh.ChiTiet;
            txtCachSuDung.Text = nppsd.CachSuDung.ToString();
            txtSoLuong.Text = nppsd.SoLuong.ToString();
            if (chkMinhHoa.Checked == true)
                nppsd.MinhHoa = true;
            else
                nppsd.MinhHoa = false;
            //fileAnhMH.HasFile = npp.AnhMH;
            lmh.MaLMH = nppsd.MaLMH;
            droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
        }
        else
        {
            khsd.MaKHSD = int.Parse(griMatHangDaDung.SelectedValue.ToString());
            khsd.CT();
            txtMaMH.Text = khsd.MaMH.ToString();
            txtMaMH.ReadOnly = true;
            txtTenMH.Text = khsd.TenMH;
            txtGia.Text = khsd.Gia.ToString();
            txtChiTiet.Text = khsd.ChiTiet;
            //fckChiTiet.Text = mh.ChiTiet;
            txtCachSuDung.Text = khsd.CachSuDung.ToString();
            txtSoLuong.Text = khsd.SoLuong.ToString();
            if (chkMinhHoa.Checked == true)
                khsd.MinhHoa = true;
            else
                khsd.MinhHoa = false;
            //fileAnhMH.HasFile = npp.AnhMH;
            lmh.MaLMH = khsd.MaLMH;
            droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
        }       
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if (Session["MaKH"].ToString() == null)// nếu không click khách hàng nào
        {
            nppsd.MaNPPSD = int.Parse(griMatHangDaDung.SelectedValue.ToString());
            nppsd.Xoa();
            lblTB.Visible = true;
            lblTB.Text = nppsd.ThongBao;
            griMatHangDaDung.DataSource = nppsd.MatHang_DaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
            griMatHangDaDung.DataBind();
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtGia.Text = "";
            txtChiTiet.Text = "";
            //fckChiTiet.Text = "";
            txtCachSuDung.Text = "";
            pnlChiTietMH.Visible = false;
        }
        else
        {
            khsd.MaKHSD = int.Parse(griMatHangDaDung.SelectedValue.ToString());
            khsd.Xoa();
            lblTB.Visible = true;
            lblTB.Text = khsd.ThongBao;
            griMatHangDaDung.DataSource = khsd.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griMatHangDaDung.DataBind();
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtGia.Text = "";
            txtChiTiet.Text = "";
            //fckChiTiet.Text = "";
            txtCachSuDung.Text = "";
            pnlChiTietMH.Visible = false;
        }
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bSoLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text);
        if (bSoLuong == false)
        {
            if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
            {
                nppsd.SoLuong = int.Parse(txtSoLuong.Text);
                if (chkMinhHoa.Checked == true)
                    nppsd.MinhHoa = true;
                else
                    nppsd.MinhHoa = false;
                nppsd.MaNPPSD = int.Parse(griMatHangDaDung.SelectedValue.ToString());
                nppsd.Sua();
                griMatHangDaDung.DataSource = nppsd.MatHang_DaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
                griMatHangDaDung.DataBind();
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
                khsd.MaKHSD = int.Parse(griMatHangDaDung.SelectedValue.ToString());
                khsd.Sua();
                griMatHangDaDung.DataSource = khsd.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
                griMatHangDaDung.DataBind();
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
        griMatHangDaDung.PageIndex = e.NewPageIndex;
        if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
        {
            griMatHangDaDung.DataSource = nppsd.MatHang_DaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
            griMatHangDaDung.DataBind();
        }
        else
        {
            griMatHangDaDung.DataSource = khsd.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griMatHangDaDung.DataBind();
        }
    }
}