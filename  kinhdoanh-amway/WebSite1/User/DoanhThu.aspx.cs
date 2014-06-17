using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DoanhThu : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.DoanhThu dt = new webdoan.DoanhThu();
    webdoan.SanPham sp = new webdoan.SanPham();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["MaNPP"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
            {
                griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
                lbtThemMoi.Visible = true;
            }
            else
            {
                griDoanhThu.DataSource = dt.DS(Session["MaNPPClick"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem thông tin doanh thu của: " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
                lbtThemMoi.Visible = false;
            }
            griDoanhThu.DataBind();
        }
    }
    protected void griDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietDoanhThu.Visible = true;
        lbtThemMoi.Visible = false;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            dt.MaNPP = Session["MaNPP"].ToString();
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        else
            dt.MaNPP = Session["MaNPPClick"].ToString();
        dt.ThangNam = griDoanhThu.SelectedValue.ToString();
        dt.CT();
        txtThangNam.Text = dt.ThangNam;
        txtThangNam.Enabled = true;
        txtDiem.Text = dt.Diem.ToString();
        txtDoanhThu_NPP.Text = sp.DoanhThu_NPP(dt.MaNPP, dt.ThangNam).ToString();
        txtDoanhThu_KH.Text = sp.DoanhThu_KH(dt.MaNPP, dt.ThangNam).ToString();
    }
    protected void griDoanhThu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griDoanhThu.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
            griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
        else
            griDoanhThu.DataSource = dt.DS(Session["MaNPPClick"].ToString());
        griDoanhThu.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        pnlChiTietDoanhThu.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtThangNam.Text = "";
        txtDiem.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bThangNam = string.IsNullOrWhiteSpace(txtThangNam.Text);
        bool bDiem = string.IsNullOrWhiteSpace(txtDiem.Text);
        if (bThangNam == false && bDiem == false)
        {
            dt.MaNPP = Session["MaNPP"].ToString();
            dt.ThangNam = txtThangNam.Text;
            dt.Diem = int.Parse(txtDiem.Text);            
            dt.Them();
            lblTB.Visible = true;
            lblTB.Text = dt.ThongBao;
            griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
            griDoanhThu.DataBind();
            pnlChiTietDoanhThu.Visible = false;
            lbtThemMoi.Visible = true;
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        dt.MaNPP = Session["MaNPP"].ToString();
        dt.ThangNam = txtThangNam.Text;
        dt.Xoa();
        lblTB.Visible = true;
        lblTB.Text = dt.ThongBao;
        griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
        griDoanhThu.DataBind();
        txtThangNam.Text = "";
        txtDiem.Text = "";
        pnlChiTietDoanhThu.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bThangNam = string.IsNullOrWhiteSpace(txtThangNam.Text);
        bool bDiem = string.IsNullOrWhiteSpace(txtDiem.Text);
        if (bThangNam == false && bDiem == false)
        {
            dt.MaNPP = Session["MaNPP"].ToString();
            dt.ThangNam = txtThangNam.Text;
            dt.Diem = int.Parse(txtDiem.Text);
            dt.Sua();
            lblTB.Visible = true;
            lblTB.Text = dt.ThongBao;
            griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
            griDoanhThu.DataBind();
            pnlChiTietDoanhThu.Visible = false;
            lbtThemMoi.Visible = true;
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietDoanhThu.Visible = false;
        if (Session["MaNPPClick"] == null)
            lbtThemMoi.Visible = true;
        else
            lbtThemMoi.Visible = false;
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
    protected void btnTraDoanhThu_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            dt.MaNPP = Session["MaNPP"].ToString();
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        else
            dt.MaNPP = Session["MaNPPClick"].ToString();
        dt.ThangNam = txtThangNam.Text;
        txtDoanhThu_NPP.Text = sp.DoanhThu_NPP(dt.MaNPP, dt.ThangNam).ToString();
        txtDoanhThu_KH.Text = sp.DoanhThu_KH(dt.MaNPP, dt.ThangNam).ToString();

    }
}