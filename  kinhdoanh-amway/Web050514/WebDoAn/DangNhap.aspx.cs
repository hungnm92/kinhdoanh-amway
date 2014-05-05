using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Subgurim.Controles;

public partial class User_DangNhap : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["MaNPPClick"] = null;//Khi quay lại trang đăng nhập thì xóa biến session click
            Session["MaNPP"] = null;
            Session["MaKH"] = null;
            Session["MaCD"] = null;
            Session["MaLMH"] = null;
            Session["Loai"] = null;
            DataTable dt = this.GetData("select * from Locations");
            rptMarkers.DataSource = dt;
            rptMarkers.DataBind();
        }
    }
    private DataTable GetData(string query)
    {
        string conString = "server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn;";
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;

                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
    //GooleMap tìm kiếm
    
    protected void btnShowMap_Click(object sender, EventArgs e)
        {
            string fulladdress = string.Format("{0}.{1}.{2}", txtStreet.Text, txtCity.Text, txtCountry.Text);
            string skey = ConfigurationManager.AppSettings["AIzaSyDtm1ZEb3am5hBseCQxi3gcyyOcYCso7Zc"];
            GeoCode geocode;
            geocode = GMap1.getGeoCodeRequest(fulladdress);
            var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
            GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            var oMarker = new Subgurim.Controles.GMarker(glatlng);
            GMap1.addGMarker(oMarker);
        }
    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        npp.MaNPP = txtMaNPP.Text;
        npp.MatKhau = txtMatKhau.Text;
        if ((string.IsNullOrWhiteSpace(txtMatKhau.Text) == false) && (string.IsNullOrWhiteSpace(txtMaNPP.Text) == false))
        {
            if (npp.DangNhap() == true)
            {
                Session["MaNPP"] = npp.MaNPP;
                Session["HoTenNPP"] = npp.HoNPP + " " + npp.TenNPP;
                Response.Redirect("~/User/TrangChu.aspx");
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
            }
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập mã ADA hoặc mật khẩu.";
        }
    }
}