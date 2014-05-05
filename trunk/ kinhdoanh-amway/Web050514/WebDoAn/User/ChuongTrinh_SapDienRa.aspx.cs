using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChuongTrinh_SapDienRa : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.KhachHang kh = new webdoan.KhachHang();
    webdoan.ChuongTrinh ct = new webdoan.ChuongTrinh();
    webdoan.DaoTao dt = new webdoan.DaoTao();
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaKH"] == null)
        {
            if (Session["MaNPPClick"] == null)
            {
                lbtThemMoi.Visible = true;
            }
            else
            {
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem chương trình sắp diễn ra của: " + npp.HoNPP + " " + npp.TenNPP;
                lbtThemMoi.Visible = false;
                lbtTroVe.Visible = true;
            }
        }
        else
        {
            if (Session["MaNPPClick"] == null)
            {
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem chương trình sắp diễn ra của khách hàng: " + kh.HoKH + " " + kh.TenKH;
                lbtTroVe.Visible = true;
                lbtThemMoi.Visible = false;
            }
            else
            {
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem chương trình sắp diễn ra của " + kh.HoKH + " " + kh.TenKH + " là khách hàng " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
                lbtThemMoi.Visible = false;
            }
        }
        griChuongTrinhSapDienRa.DataSource = ct.DS();
        griChuongTrinhSapDienRa.DataBind();
    }
    protected void griChuongTrinhSapDienRa_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        if (Session["MaNPPClick"] == null && Session["MaKH"] == null)
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        btnIn.Visible = true;
        btnThoat.Visible = true;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            if (Session["MaKH"] == null)
                btnDaoTao.Visible = true;
            else
                btnChamSoc.Visible = true;
        }
        else
        {
            btnDaoTao.Visible = false;
            btnChamSoc.Visible = false;
        }
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
        btnChamSoc.Visible = false;
        btnDaoTao.Visible = false;
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
            txtMaCT.Enabled = true;
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
        griChuongTrinhSapDienRa.DataSource = ct.DS();
        griChuongTrinhSapDienRa.DataBind();
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
            ct.Sua();
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
        if (Session["MaNPPClick"] == null && Session["MaKH"] == null)
            lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnChamSoc_Click(object sender, EventArgs e)
    {
            chkThamDu.Visible = true;
            cs.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
            cs.MaKH = Session["MaKH"].ToString();
            cs.MaNPP = Session["MaNPP"].ToString();            
            cs.ThoiGian = txtThoiGian.Text;
            if (chkThamDu.Checked == true)
                cs.ThamDu = true;
            else
                cs.ThamDu = false;
            cs.Them();
            lblTB.Visible = true;
            lblTB.Text = cs.ThongBao;
            griChuongTrinhSapDienRa.DataSource = ct.DS();
            griChuongTrinhSapDienRa.DataBind();
            pnlChiTietCT.Visible = false;      
    }
    protected void btnDaoTao_Click(object sender, EventArgs e)
    {
        dt.MaCT = griChuongTrinhSapDienRa.SelectedValue.ToString();
        dt.MaNPP = Session["MaNPP"].ToString();
        dt.NgayThamDu = txtThoiGian.Text;
        dt.Them();
        lblTB.Visible = true;
        lblTB.Text = dt.ThongBao;
        griChuongTrinhSapDienRa.DataSource = ct.DS();
        griChuongTrinhSapDienRa.DataBind();
        pnlChiTietCT.Visible = false;
    }
    protected void lbtTroVe_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["Loai"] != null)
        {
            if (Session["MaNPPClick"] != null)
            {
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                Response.Redirect("~/User/KhachHang.aspx?Loai=" + Session["Loai"] + "&MaADA=" + npp.MaNBT);
            }
            else
                Response.Redirect("~/User/KhachHang.aspx?Loai=" + Session["Loai"]);
            Session["MaKH"] = null;
        }
        else
        {
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
}