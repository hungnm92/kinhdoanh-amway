﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterPage : System.Web.UI.MasterPage
{
    webdoan.Menu mn = new webdoan.Menu();
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblMenu.Text = mn.LoadMenu(Session["MaNPP"].ToString(), 0);
        lblMenu.Text = mn.LoadMenu("2976313", 0);
        //if (Session["MaNPP"] == null)
           // Response.Redirect("~/User/DangNhap.aspx");
        //lblUser.Text = "Xin chào " + Session["HoTenNPP"].ToString() + ".";
    }

}