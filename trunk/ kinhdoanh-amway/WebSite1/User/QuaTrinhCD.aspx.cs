using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DoanhThu : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.QuaTrinhCD qtcd = new webdoan.QuaTrinhCD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["MaNPP"] == null)
                Response.Redirect("~/DangNhap.aspx");
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
                griQTCD.DataSource = qtcd.DS(Session["MaNPP"].ToString());
            else
            {
                griQTCD.DataSource = qtcd.DS(Session["MaNPPClick"].ToString());
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem quá trình đạt đến cấp độ hiện tại của: " + npp.HoNPP + " " + npp.TenNPP;
                lbtTroVe.Visible = true;
            }
            griQTCD.DataBind();
        }
    }
    protected void griQTCD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griQTCD.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
            griQTCD.DataSource = qtcd.DS(Session["MaNPP"].ToString());
        else
            griQTCD.DataSource = qtcd.DS(Session["MaNPPClick"].ToString());
        griQTCD.DataBind();
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