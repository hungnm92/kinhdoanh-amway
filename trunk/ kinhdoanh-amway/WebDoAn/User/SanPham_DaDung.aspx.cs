using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham_DaDung : System.Web.UI.Page
{
    lanhnt.NhaPhanPhoi npp = new lanhnt.NhaPhanPhoi();
    lanhnt.KhachHang kh = new lanhnt.KhachHang();
    lanhnt.LoaiMH lmh = new lanhnt.LoaiMH();
    protected void Page_Load(object sender, EventArgs e)
    {
        griMatHangDaDung.DataSource = npp.MatHang_DaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
        griMatHangDaDung.DataBind();
        // griMatHangDaDung.DataSource = kh.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
        // griMatHangDaDung.DataBind();một gri nhưng 2 danh sách.
        droLoaiMH.DataSource = lmh.DS();
        droLoaiMH.DataBind();
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = false;
        lblTB.Visible = false;
    }
    protected void griMatHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHangDaDung.PageIndex = e.NewPageIndex;
        griMatHangDaDung.DataSource = npp.MatHang_DaDung(Session["MaNPP"].ToString());// sửa có tham số truyền vào???.
        griMatHangDaDung.DataBind();
       // griMatHangDaDung.DataSource = kh.MatHang_DaDung(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
       // griMatHangDaDung.DataBind();một gri nhưng 2 danh sách.
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

    }
}