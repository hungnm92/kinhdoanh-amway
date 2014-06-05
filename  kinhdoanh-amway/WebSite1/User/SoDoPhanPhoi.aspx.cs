using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SoDoPhanPhoi : System.Web.UI.Page
{
    webdoan.Menu mn = new webdoan.Menu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaNPP"] == null)
            Response.Redirect("~/DangNhap.aspx");
        lblmenu.Text = mn.LoadMenu(Session["MaNPP"].ToString(), 0);
    }
}