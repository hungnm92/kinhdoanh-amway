using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChuongTrinh_SapDienRa : System.Web.UI.Page
{
    lanhnt.ChuongTrinh ct = new lanhnt.ChuongTrinh();
    lanhnt.DaoTao dt = new lanhnt.DaoTao();
    lanhnt.ChamSoc cs = new lanhnt.ChamSoc();
    protected void Page_Load(object sender, EventArgs e)
    {
        griChuongTrinhSapDienRa.DataSource = ct.DS();
        griChuongTrinhSapDienRa.DataBind();
    }
    protected void griChuongTrinhSapDienRa_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        if (Session["MaKH"].ToString() == null)
            btnDaoTao.Visible = true;
        else
            btnChamSoc.Visible = true;
        lblTB.Visible = false;
        ct.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
        ct.CT();
        txtMaCT.Text = ct.MaCT.ToString();
        txtTenCT.Text = ct.TenCT;
    }
    protected void griChuongTrinhSapDienRa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChuongTrinhSapDienRa.PageIndex = e.NewPageIndex;
        griChuongTrinhSapDienRa.DataSource = ct.DS();
        griChuongTrinhSapDienRa.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtMaCT.Text = "";
        txtMaCT.Enabled = true;
        txtTenCT.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaCT = string.IsNullOrWhiteSpace(txtMaCT.Text);
        bool bTenCT = string.IsNullOrWhiteSpace(txtTenCT.Text);
        if (bMaCT == false && bTenCT == false)
        {
            ct.MaCT = txtMaCT.Text;
            ct.TenCT = txtTenCT.Text;
            ct.Them();
            lblTB.Visible = true;
            lblTB.Text = ct.ThongBao;
            griChuongTrinhSapDienRa.DataSource = ct.DS();
            griChuongTrinhSapDienRa.DataBind();
            pnlChiTietCT.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập tên chương trình.";
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        ct.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
        ct.Xoa();
        lblTB.Visible = true;
        lblTB.Text = ct.ThongBao;
        txtMaCT.Text = "";
        txtTenCT.Text = "";
        pnlChiTietCT.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bTenCT = string.IsNullOrWhiteSpace(txtTenCT.Text);
        if (bTenCT == false)
        {
            ct.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
            ct.TenCT = txtTenCT.Text;           
            ct.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
            lblTB.Visible = true;
            lblTB.Text = ct.ThongBao;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập tên chương trình.";
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = false;
        lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnChamSoc_Click(object sender, EventArgs e)
    {
            chkThamDu.Visible = true;
            cs.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
            cs.MaKH = Session["MaKH"].ToString();
            cs.MaNPP = Session["MaNPP"].ToString();
            if (chkThamDu.Checked == true)
                cs.ThamDu = true;
            else
                cs.ThamDu = false;
            cs.Them();
            lblTB.Visible = true;
            lblTB.Text = ct.ThongBao;
            griChuongTrinhSapDienRa.DataSource = ct.DS();
            griChuongTrinhSapDienRa.DataBind();
            pnlChiTietCT.Visible = false;
            lbtThemMoi.Visible = true;       
    }
    protected void btnDaoTao_Click(object sender, EventArgs e)
    {
        dt.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
        dt.MaNPP = Session["MaNPP"].ToString();
        dt.Them();
        lblTB.Visible = true;
        lblTB.Text = ct.ThongBao;
        griChuongTrinhSapDienRa.DataSource = ct.DS();
        griChuongTrinhSapDienRa.DataBind();
        pnlChiTietCT.Visible = false;
        lbtThemMoi.Visible = true;
    }
}