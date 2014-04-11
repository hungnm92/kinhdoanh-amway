using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham_ChuaDung : System.Web.UI.Page
{
    lanhnt.NPPSuDung nppsd = new lanhnt.NPPSuDung();
    lanhnt.KHSuDung khsd = new lanhnt.KHSuDung();
    lanhnt.LoaiMH lmh = new lanhnt.LoaiMH();
    lanhnt.MatHang mh = new lanhnt.MatHang();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
        {
            griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
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
        mh.MaMH = int.Parse(griMatHangChuaDung.SelectedValue.ToString());
        mh.CT();
        txtMaMH.Text = npp.MaMH.ToString();
        txtMaMH.ReadOnly = true;
        txtTenMH.Text = npp.TenMH;
        txtGia.Text = npp.Gia.ToString();
        txtChiTiet.Text = npp.ChiTiet;
        //fckChiTiet.Text = mh.ChiTiet;
        txtCachSuDung.Text = npp.CachSuDung.ToString();
        //fileAnhMH.HasFile = npp.AnhMH;
        lmh.MaLMH = npp.MaLMH;
        droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
    }
    protected void griMatHangChuaDung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHangChuaDung.PageIndex = e.NewPageIndex;
        if (Session["MaKH"].ToString() == null)//một gri nhưng 2 danh sách. không biết đúng không
        {
            griMatHangChuaDung.DataSource = nppsd.MatHang_ChuaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
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
            nppsd.MaMH = int.Parse(griMatHangChuaDung.SelectedValue.ToString());
            nppsd.MaNPP = Session["MaNPP"].ToString();
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
            khsd.MaMH = int.Parse(griMatHangChuaDung.SelectedValue.ToString());
            khsd.MaKH = Session["MaKH"].ToString();
            khsd.MaNPP = Session["MaNPP"].ToString();
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