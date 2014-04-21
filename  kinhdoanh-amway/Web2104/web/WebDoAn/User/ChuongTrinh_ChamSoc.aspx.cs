using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChuongTrinh_ChamSoc : System.Web.UI.Page
{
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    webdoan.ChuongTrinh ct = new webdoan.ChuongTrinh();
    protected void Page_Load(object sender, EventArgs e)
    {
        griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(),Session["MaKH"].ToString());
        griChuongTrinhChamSoc.DataBind();
        droChuongTrinh.DataSource = ct.DS();
        droChuongTrinh.DataBind();
    }
    protected void griChuongTrinhChamSoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChuongTrinhChamSoc.PageIndex = e.NewPageIndex;
        griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
        griChuongTrinhChamSoc.DataBind();
    }
    protected void griChuongTrinhChamSoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        cs.MaCS = griChuongTrinhChamSoc.SelectedValue.ToString();
        cs.CT();
        txtMaCS.Text = cs.MaCS;
        txtThoiGian.Text = cs.ThoiGian;
        txtSoLan.Text = cs.SoLan.ToString();
        if (chkThamDu.Checked == true)
            cs.ThamDu = true;
        else
            cs.ThamDu = false;
        ct.MaCT = cs.MaCT;
        droChuongTrinh.SelectedValue = ct.MaCT.ToString();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cs.MaCS = griChuongTrinhChamSoc.SelectedValue.ToString();
        cs.Xoa();
        lblTB.Visible = true;
        lblTB.Text = ct.ThongBao;
        txtMaCS.Text = "";
        txtThoiGian.Text = "";
        txtSoLan.Text = "";
        chkThamDu.Checked = false;
        pnlChiTietCT.Visible = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
            cs.MaCS = griChuongTrinhChamSoc.SelectedValue.ToString();
            cs.MaCT = droChuongTrinh.SelectedValue;
            if (chkThamDu.Checked == true)
                cs.ThamDu = true;
            else
                cs.ThamDu = false;
            cs.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
            lblTB.Visible = true;
            lblTB.Text = cs.ThongBao;
            griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griChuongTrinhChamSoc.DataBind();
            pnlChiTietCT.Visible = false;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = false;
        lblTB.Visible = false;
    }
}