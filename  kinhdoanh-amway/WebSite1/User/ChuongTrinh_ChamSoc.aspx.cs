using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChuongTrinh_ChamSoc : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.KhachHang kh = new webdoan.KhachHang();
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    webdoan.ChuongTrinh ct = new webdoan.ChuongTrinh();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaKH"] == null)
        {
            griChuongTrinhChamSoc.Visible = false;
            griChuongTrinhChamSocNPP.Visible = true;
            if (Session["MaNPPClick"] == null)                
                griChuongTrinhChamSocNPP.DataSource = cs.DS_NPP(Session["MaNPP"].ToString());
            else
            {
                griChuongTrinhChamSocNPP.DataSource = cs.DS_NPP(Session["MaNPPClick"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem quá trình chăm sóc của: " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
            }
            griChuongTrinhChamSocNPP.DataBind();
        }
        else
        {
            griChuongTrinhChamSoc.Visible = true;
            griChuongTrinhChamSocNPP.Visible = false;
            lbtTroVe.Visible = true;
            lblClick.Visible = true;
            if (Session["MaNPPClick"] == null)
            {
                griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Text = "Bạn đang xem thông tin chăm sóc của khách hàng: " + kh.HoKH + " " + kh.TenKH;
            }
            else
            {
                griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPPClick"].ToString(), Session["MaKH"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                kh.MaKH = Session["MaKH"].ToString();
                kh.CT();
                lblClick.Text = "Bạn đang xem thông tin chăm sóc của " + kh.HoKH + " " + kh.TenKH + " là khách hàng " + npp.HoNPP + " " + npp.TenNPP;
            }
            griChuongTrinhChamSoc.DataBind();
        }
        droChuongTrinh.DataSource = ct.DS();
        droChuongTrinh.DataBind();
    }
    protected void griChuongTrinhChamSoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChuongTrinhChamSoc.PageIndex = e.NewPageIndex;
        if (Session["MaKH"] == null)
        {
            griChuongTrinhChamSoc.Visible = false;
            griChuongTrinhChamSocNPP.Visible = true;
            if (Session["MaNPPClick"] == null)
                griChuongTrinhChamSocNPP.DataSource = cs.DS_NPP(Session["MaNPP"].ToString());
            else
                griChuongTrinhChamSocNPP.DataSource = cs.DS_NPP(Session["MaNPPClick"].ToString());
            griChuongTrinhChamSocNPP.DataBind();
        }
        else
        {
            griChuongTrinhChamSoc.Visible = true;
            griChuongTrinhChamSocNPP.Visible = false;
            if (Session["MaNPPClick"] == null)
                griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            else
                griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPPClick"].ToString(), Session["MaKH"].ToString());
            griChuongTrinhChamSoc.DataBind();
        }
    }
    protected void griChuongTrinhChamSoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietCT.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        if (Session["MaNPPClick"] == null)
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }
        if (Session["MaKH"] == null)
            cs.MaCS = griChuongTrinhChamSocNPP.SelectedValue.ToString();
        else
            cs.MaCS = griChuongTrinhChamSoc.SelectedValue.ToString();
        cs.CT();
        txtMaCS.Text = cs.MaCS;
        //txtNgayCS.Text = cs.NgayCS;
        string temp1 = cs.NgayCS.ToString().Replace(" 12:00:00 AM", "");
        temp1 = temp1.Substring(8, 2) + "/" + temp1.Substring(5, 2) + "/" + temp1.Substring(0, 4);
        txtNgayCS.Text = temp1;
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
        if (Session["MaKH"] == null)
        {
            cs.MaCS = griChuongTrinhChamSocNPP.SelectedValue.ToString();
            cs.Xoa();
            lblTB.Visible = true;
            lblTB.Text = cs.ThongBao;
            txtMaCS.Text = "";
            txtNgayCS.Text = "";
            txtSoLan.Text = "";
            chkThamDu.Checked = false;
            pnlChiTietCT.Visible = false;
            griChuongTrinhChamSoc.DataSource = cs.DS_NPP(Session["MaNPP"].ToString());
            griChuongTrinhChamSoc.DataBind();
        }
        else
        {
            cs.MaCS = griChuongTrinhChamSoc.SelectedValue.ToString();
            cs.Xoa();
            lblTB.Visible = true;
            lblTB.Text = cs.ThongBao;
            txtMaCS.Text = "";
            txtNgayCS.Text = "";
            txtSoLan.Text = "";
            chkThamDu.Checked = false;
            pnlChiTietCT.Visible = false;
            griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
            griChuongTrinhChamSoc.DataBind();
        }
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        cs.NgayCS = txtNgayCS.Text;
        if (chkThamDu.Checked == true)
            cs.ThamDu = true;
        else
            cs.ThamDu = false;
        if (Session["MaKH"] == null)
        {
            cs.MaCS = griChuongTrinhChamSocNPP.SelectedValue.ToString();
            cs.Sua();
            lblTB.Visible = true;
            lblTB.Text = cs.ThongBao;
            griChuongTrinhChamSoc.DataSource = cs.DS_NPP(Session["MaNPP"].ToString());
        }
        else
        {
            cs.MaCS = griChuongTrinhChamSoc.SelectedValue.ToString();
            cs.Sua();
            lblTB.Visible = true;
            lblTB.Text = cs.ThongBao;
            griChuongTrinhChamSoc.DataSource = cs.DS(Session["MaNPP"].ToString(), Session["MaKH"].ToString());
        }
            griChuongTrinhChamSoc.DataBind();
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
        if (Session["Loai"] != null)
        {
            Session["MaKH"] = null;
            if (Session["MaNPPClick"] != null)
                Response.Redirect("~/User/KhachHang.aspx?Loai=" + Session["Loai"] + "&MaADA=" + Session["MaNPPClick"].ToString());
            else
                Response.Redirect("~/User/KhachHang.aspx?Loai=" + Session["Loai"]);
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