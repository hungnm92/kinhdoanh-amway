using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChuongTrinh_DaoTao : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.DaoTao dt = new webdoan.DaoTao();
    webdoan.ChuongTrinh ct = new webdoan.ChuongTrinh();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaNPP"] == null)
            Response.Redirect("~/DangNhap.aspx");
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
            griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        else
        {
            griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPPClick"].ToString());
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.CT();
            lblClick.Visible = true;
            lblClick.Text = "Bạn đang xem quá trình đào tạo của: " + npp.HoNPP + " " + npp.TenNPP;
            lbtTroVe.Visible = true;
        }
        griChuongTrinhDaoTao.DataBind();
        droChuongTrinh.DataSource = ct.DS();
        droChuongTrinh.DataBind();
    }
    protected void griChuongTrinhDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        if (Session["MaNPPClick"] == null)
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        dt.MaDT = griChuongTrinhDaoTao.SelectedValue.ToString();
        dt.CT();
        txtMaDT.Text = dt.MaDT;
        //txtNgayDT.Text = dt.NgayDT;
        string temp1 = dt.NgayDT.ToString().Replace("12:00:00 AM", "");
        txtNgayDT.Text = temp1;
        txtSoLan.Text = dt.SoLan.ToString();
        ct.MaCT = dt.MaCT;
        droChuongTrinh.SelectedValue = ct.MaCT.ToString();
    }
    protected void griChuongTrinhDaoTao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChuongTrinhDaoTao.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
            griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        else
            griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPPClick"].ToString());
        griChuongTrinhDaoTao.DataBind();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        dt.MaDT = griChuongTrinhDaoTao.SelectedValue.ToString();
        dt.Xoa();
        lblTB.Visible = true;
        lblTB.Text = dt.ThongBao;
        txtMaDT.Text = "";
        txtNgayDT.Text = "";
        txtSoLan.Text = "";
        pnlChiTietCT.Visible = false;
        griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        griChuongTrinhDaoTao.DataBind();
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        dt.MaDT = txtMaDT.Text;
        dt.MaCT = droChuongTrinh.SelectedValue;
        dt.Sua();
        griChuongTrinhDaoTao.DataSource = dt.DS(Session["MaNPP"].ToString());
        griChuongTrinhDaoTao.DataBind();
        lblTB.Visible = true;
        lblTB.Text = dt.ThongBao;
        pnlChiTietCT.Visible = false;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = false;
        lblTB.Visible = false;
    }
    protected void lbtTroVe_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
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