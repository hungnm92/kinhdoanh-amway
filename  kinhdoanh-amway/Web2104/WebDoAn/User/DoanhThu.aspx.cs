using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DoanhThu : System.Web.UI.Page
{
    webdoan.DoanhThu dt = new webdoan.DoanhThu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
            griDoanhThu.DataBind();
        }
    }
    protected void griDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietDoanhThu.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        dt.MaNPP = Session["MaNPP"].ToString(); 
        dt.ThangNam = griDoanhThu.SelectedValue.ToString();
        dt.CT();
        txtThangNam.Text = dt.ThangNam;
        txtThangNam.Enabled = true;
        txtDiem.Text = dt.Diem.ToString();
    }
    protected void griDoanhThu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griDoanhThu.PageIndex = e.NewPageIndex;
        griDoanhThu.DataSource = dt.DS(Session["MaNPP"].ToString());
        griDoanhThu.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
        // Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietDoanhThu.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnIn.Visible = true;
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
        lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
}