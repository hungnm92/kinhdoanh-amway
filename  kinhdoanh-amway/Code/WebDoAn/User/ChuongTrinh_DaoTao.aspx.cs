using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChuongTrinh_DaoTao : System.Web.UI.Page
{
    lanhnt.DaoTao dt = new lanhnt.DaoTao();
    lanhnt.ChuongTrinh ct = new lanhnt.ChuongTrinh();
    protected void Page_Load(object sender, EventArgs e)
    {
        griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        griChuongTrinhDaoTao.DataBind();
        droChuongTrinh.DataSource = ct.DS();
        droChuongTrinh.DataBind();
    }
    protected void griChuongTrinhDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        dt.MaDaoTao = griChuongTrinhDaoTao.SelectedValue.ToString();
        dt.CT();
        txtMaDaoTao.Text = dt.MaDaoTao;
        txtNgayThamDu.Text = dt.NgayThamDu;
        txtSoLan.Text = dt.SoLan.ToString();
        ct.MaCT = dt.MaCT;
        droChuongTrinh.SelectedValue = ct.MaCT.ToString();
    }
    protected void griChuongTrinhDaoTao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChuongTrinhDaoTao.PageIndex = e.NewPageIndex;
        griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        griChuongTrinhDaoTao.DataBind();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        dt.MaDaoTao = griChuongTrinhDaoTao.SelectedValue.ToString();
        dt.Xoa();
        lblTB.Visible = true;
        lblTB.Text = ct.ThongBao;
        txtMaDaoTao.Text = "";
        txtNgayThamDu.Text = "";
        txtSoLan.Text = "";
        pnlChiTietCT.Visible = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        dt.MaDaoTao = griChuongTrinhDaoTao.SelectedValue.ToString();
        dt.MaCT = droChuongTrinh.SelectedValue;
        dt.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
        lblTB.Visible = true;
        lblTB.Text = dt.ThongBao;
        griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        griChuongTrinhDaoTao.DataBind();
        pnlChiTietCT.Visible = false;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = false;
        lblTB.Visible = false;
    }
}