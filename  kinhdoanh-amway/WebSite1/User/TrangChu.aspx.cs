using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

public partial class User_Default : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.CapDo cd = new webdoan.CapDo();
    webdoan.Duong dll = new webdoan.Duong();
    webdoan.Duong dtt = new webdoan.Duong();
    webdoan.XaPhuong xpll = new webdoan.XaPhuong();
    webdoan.XaPhuong xptt = new webdoan.XaPhuong();
    webdoan.Huyen hll = new webdoan.Huyen();
    webdoan.Huyen htt = new webdoan.Huyen();
    webdoan.Tinh tll = new webdoan.Tinh();
    webdoan.Tinh ttt = new webdoan.Tinh();
    webdoan.QuaTrinhCD qtcd = new webdoan.QuaTrinhCD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MaADA"] != null)
        {
            if (Request.QueryString["MaADA"] == "npp")
                Session["MaNPPClick"] = null;
            else
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
        }
        if (Session["MaNPP"] == null)
            Response.Redirect("~/DangNhap.aspx");
        if (Session["MaNPPClick"] == null)//Gán MaNPP vào để hiển thị GoogleMap khi của NPP tuyến dưới hoặc chính NPP Login
            npp.MaNPP = Session["MaNPP"].ToString();
        else
            npp.MaNPP = Session["MaNPPClick"].ToString();
            if (npp.BaoTro_SL_NEW() > 0)
                imgNew.Visible = true;
        if (IsPostBack == false)
        {
            Session["MaKH"] = null;
            string temp3;
            droDuongNPPLL.DataSource = dll.DS();
            droDuongNPPLL.DataBind();
            droDuongNPPTT.DataSource = dtt.DS();
            droDuongNPPTT.DataBind();
            droTinhNPPLL.DataSource = tll.DS();
            droTinhNPPLL.DataBind();
            droTinhNPPTT.DataSource = ttt.DS();
            droTinhNPPTT.DataBind();
            droNBT.DataSource = npp.DS();
            droNBT.DataBind();
            if (Request.QueryString["MaADA"] != null)
            {
                if (Request.QueryString["MaADA"] == "npp")
                    Session["MaNPPClick"] = null;
                else
                    Session["MaNPPClick"] = Request.QueryString["MaADA"];
            }
            if (Session["MaNPPClick"] == null)
            {
                npp.MaNPP = Session["MaNPP"].ToString();
                npp.CT();
                cd.MaCD = npp.MaCD;
                droCapDo.DataSource = cd.DS();
                droCapDo.DataBind();
                btnSua.Visible = true;
                temp3 = npp.NgayHetHan.ToString();
                temp3 = temp3.Substring(8, 2) + "/" + temp3.Substring(5, 2) + "/" + temp3.Substring(0, 4);
                npp.NgayHetHan = temp3;
                if (npp.SL_CanhBao() != 0)
                    btnGHT.Visible = true;
            }
            else
            {
                npp.MaNPP = Session["MaNPPClick"].ToString();
                npp.CT();
                temp3 = npp.NgayHetHan.ToString();
                temp3 = temp3.Substring(8, 2) + "/" + temp3.Substring(5, 2) + "/" + temp3.Substring(0, 4);
                npp.NgayHetHan = temp3;
                if (npp.MaNBT == Session["MaNPP"].ToString())
                {
                    btnSua.Visible = true;
                    if (npp.SL_CanhBao() != 0)
                        btnGHT.Visible = true;
                }
                cd.MaCD = npp.MaCD;
                droCapDo.DataSource = cd.DS();
                droCapDo.DataBind();
                lblClick.Visible = true;
                lblClick.Text = "Bạn đang xem: " + npp.HoNPP + " " + npp.TenNPP;
            }
            if (Session["MaNPP"] == "0000000" || npp.MaNBT == Session["MaNPP"].ToString())
            {
                btnSua.Visible = true;
                if (npp.SL_CanhBao() != 0)
                    btnGHT.Visible = true;
                droNBT.Visible = true;
            }
            txtMaNPP.Text = npp.MaNPP;
            txtHoNPP.Text = npp.HoNPP;
            txtTenNPP.Text = npp.TenNPP;
            //txtNgaySinh.Text = npp.NgaySinh;
            string temp1 = npp.NgaySinh.ToString().Replace(" 12:00:00 AM", "");
            temp1 = temp1.Substring(8, 2) + "/" + temp1.Substring(5, 2) + "/" + temp1.Substring(0, 4);
            txtNgaySinh.Text = temp1;
            txtNgaySinh.Enabled = false;
            if (npp.GioiTinh == true)
            {
                rdoNu.Checked = false;
                rdoNam.Checked = true;
            }
            else
            {
                rdoNam.Checked = false;
                rdoNu.Checked = true;
            }
            imgAnhNPP.ImageUrl = "~/src/emp/" + npp.AnhNPP;
            txtCMND.Text = npp.CMND;
            txtSoDT.Text = npp.SoDT;
            txtEmail.Text = npp.Email;
            //txtNgayKyThe.Text = npp.NgayKyThe;
            string temp2 = npp.NgayKyThe.ToString().Replace(" 12:00:00 AM", "");
            temp2 = temp2.Substring(8, 2) + "/" + temp2.Substring(5, 2) + "/" + temp2.Substring(0, 4);
            txtNgayKyThe.Text = temp2;
            txtNgayKyThe.Enabled = false;
            //txtNgayHetHan.Text = npp.NgayHetHan;
            txtNgayHetHan.Text = npp.NgayHetHan;
            txtNgayHetHan.Enabled = false;
            txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
            txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
            cd.MaCD = npp.MaCD;
            droCapDo.SelectedValue = cd.MaCD.ToString();
            npp.CanhBao();
            lblCanhBao.Text = npp.ThongBao;
            //Tinh
            tll.MaTinh = npp.MaTinhNPPLL;
            droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
            ttt.MaTinh = npp.MaTinhNPPTT;
            droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
            //Huyen
            droTinhNPPLL_SelectedIndexChanged(sender, e);
            //droHuyenNPPLL.DataSource = hll.DS_TheoTinh(tll.MaTinh);
           // droHuyenNPPLL.DataBind();           
            droTinhNPPTT_SelectedIndexChanged(sender, e);
            //droHuyenNPPTT.DataSource = htt.DS_TheoTinh(ttt.MaTinh);
            //droHuyenNPPTT.DataBind();
            hll.MaHuyen = npp.MaHuyenNPPLL;
            droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
            htt.MaHuyen = npp.MaHuyenNPPTT;
            droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
            //Xa
            droHuyenNPPLL_SelectedIndexChanged(sender, e);
            //droXaNPPLL.DataSource = xpll.DS(hll.MaHuyen);
            //droXaNPPLL.DataBind();
            droHuyenNPPTT_SelectedIndexChanged(sender, e);
            //droXaNPPTT.DataSource = xptt.DS(htt.MaHuyen);
            //droXaNPPTT.DataBind();
            xpll.MaXa = npp.MaXaNPPLL;
            droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
            xptt.MaXa = npp.MaXaNPPTT;
            droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
            //Duong
            dll.MaDuong = npp.MaDuongNPPLL;
            droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
            dtt.MaDuong = npp.MaDuongNPPTT;
            droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
            //Hien dro Nha Bao Tro
            npp.MaNPP = npp.MaNBT;
            droNBT.SelectedValue = npp.MaNPP.ToString();
 //           lbtViewMap.Visible = true;
            GMap1.Visible = false;
        }
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            if(rdoNam.Checked == true)
                npp.GioiTinh = true;
            else
                npp.GioiTinh = false;
            string DuongDan = "";
            string ReName = txtMaNPP.Text;
            DuongDan = Server.MapPath("~/src/emp/");
            DuongDan = DuongDan + ReName + ".jpg";
            fileAnhNPP.SaveAs(DuongDan);
            npp.AnhNPP = ReName + ".jpg";
            npp.CMND = txtCMND.Text;
            npp.SoDT = txtSoDT.Text;
            npp.Email = txtEmail.Text;
            npp.NgayHetHan = txtNgayHetHan.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
            npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
            npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
            npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
            qtcd.MaCD = int.Parse(droCapDo.SelectedValue);
            qtcd.MaNPP = npp.MaNPP;
            txtNgayKyThe0_CalendarExtender.SelectedDate = DateTime.Today;
            qtcd.ThoiGian = txtNgayKyThe0.Text;//lấy ngày hệ thống
            qtcd.Them();
            if (Session["MaNPP"] == "0000000")
            {
                droNBT.Enabled = true;
                npp.MaNBT = droNBT.SelectedValue;
                npp.Sua_NhaBaoTro();
            }
            else
                droNBT.Enabled = false;
            npp.Sua();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
        }
        else
            if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == false)
            {
                npp.MaNPP = Session["MaNPP"].ToString();
                npp.CT();
                string temp = npp.AnhNPP.ToString();
                npp.HoNPP = txtHoNPP.Text;
                npp.TenNPP = txtTenNPP.Text;
                npp.NgaySinh = txtNgaySinh.Text;
                if (rdoNam.Checked == true)
                    npp.GioiTinh = true;
                else
                    npp.GioiTinh = false;
                npp.AnhNPP = temp;
                npp.CMND = txtCMND.Text;
                npp.SoDT = txtSoDT.Text;
                npp.Email = txtEmail.Text;
                npp.NgayHetHan = txtNgayHetHan.Text;
                npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
                npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
                npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
                npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
                npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
                npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
                npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
                npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
                npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
                npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
                qtcd.MaCD = int.Parse(droCapDo.SelectedValue);
                qtcd.MaNPP = npp.MaNPP;
                txtNgayKyThe0_CalendarExtender.SelectedDate = DateTime.Today;
                qtcd.ThoiGian = txtNgayKyThe0.Text;//lấy ngày hệ thống
                qtcd.Them();
                if (Session["MaNPP"] == "0000000")
                {
                    droNBT.Enabled = true;
                    npp.MaNBT = droNBT.SelectedValue;
                    npp.Sua_NhaBaoTro();
                }
                else
                    droNBT.Enabled = false;
                npp.Sua();
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Các vị trí * bắt buộc bạn phải nhập.";
            }
    }
    protected void btnShowMap_Click(object sender, EventArgs e)
    {
        //string fulladdress;
        //if(txtSoNhaNPPLL.Text == null && droDuongNPPLL.SelectedValue == "0000")
        string fulladdress = string.Format("{0}, {1}, {2}, {3}, {4}", txtSoNhaNPPLL.Text, droDuongNPPLL.SelectedItem, droXaNPPLL.SelectedItem, droHuyenNPPLL.SelectedItem, "Việt Nam");
        //fulladdress = string.Format("{0}.{1}.{2}", droHuyenNPPLL.SelectedItem , droTinhNPPLL.SelectedItem, "Việt Nam");
        string skey = ConfigurationManager.AppSettings["http://googlemaps.subgurim.net"];
        GeoCode geocode;
        geocode = GMap1.getGeoCodeRequest(fulladdress);
        var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
        GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
        var oMarker = new Subgurim.Controles.GMarker(glatlng);
        //GMap1.addGMarker(oMarker);
        GMap1.Add(oMarker);
    }
    protected void btnShowMapfull_Click(object sender, EventArgs e)
    {
        //string fulladdress;
        //if(txtSoNhaNPPLL.Text == null && droDuongNPPLL.SelectedValue == "0000")
        string fulladdress = string.Format("{0}, {1}, {2}, {3}", droXaNPPLL.SelectedItem, droHuyenNPPLL.SelectedItem, droTinhNPPLL.SelectedItem, "Việt Nam");
        //fulladdress = string.Format("{0}.{1}.{2}", droHuyenNPPLL.SelectedItem , droTinhNPPLL.SelectedItem, "Việt Nam");
        string skey = ConfigurationManager.AppSettings["http://googlemaps.subgurim.net"];
        GeoCode geocode;
        geocode = GMap1.getGeoCodeRequest(fulladdress);
        var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
        GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
        var oMarker = new Subgurim.Controles.GMarker(glatlng);
        //GMap1.addGMarker(oMarker);
        GMap1.Add(oMarker);
    }
    protected void btnShowMapNull_SN_Click(object sender, EventArgs e)
    {
        //string fulladdress;
        //if(txtSoNhaNPPLL.Text == null && droDuongNPPLL.SelectedValue == "0000")
        string fulladdress = string.Format("{0}, {1}, {2}, {3}", droDuongNPPLL.SelectedItem, droXaNPPLL.SelectedItem, droHuyenNPPLL.SelectedItem, "Việt Nam");
        //fulladdress = string.Format("{0}.{1}.{2}", droHuyenNPPLL.SelectedItem , droTinhNPPLL.SelectedItem, "Việt Nam");
        string skey = ConfigurationManager.AppSettings["http://googlemaps.subgurim.net"];
        GeoCode geocode;
        geocode = GMap1.getGeoCodeRequest(fulladdress);
        var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
        GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
        var oMarker = new Subgurim.Controles.GMarker(glatlng);
        //GMap1.addGMarker(oMarker);
        GMap1.Add(oMarker);
    }
    protected void droTinhNPPTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
        droHuyenNPPTT.Items.Clear();
        droHuyenNPPTT.DataSource = htt.DS_TheoTinh(npp.MaTinhNPPTT);
        droHuyenNPPTT.DataBind();
        droXaNPPTT.DataSource = xptt.DS(droHuyenNPPTT.SelectedValue);
        droXaNPPTT.DataBind();
    }
    protected void droHuyenNPPTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
        droXaNPPTT.Items.Clear();
        droXaNPPTT.DataSource = xptt.DS(npp.MaHuyenNPPTT);
        droXaNPPTT.DataBind();
    }
    protected void droTinhNPPLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
        droHuyenNPPLL.Items.Clear();
        droHuyenNPPLL.DataSource = hll.DS_TheoTinh(npp.MaTinhNPPLL);
        droHuyenNPPLL.DataBind();
        droXaNPPLL.DataSource = xpll.DS(droHuyenNPPLL.SelectedValue);
        droXaNPPLL.DataBind();
    }
    protected void droHuyenNPPLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
        droXaNPPLL.Items.Clear();
        droXaNPPLL.DataSource = xpll.DS(npp.MaHuyenNPPLL);
        droXaNPPLL.DataBind();
    }
    protected void btnGHT_Click(object sender, EventArgs e)
    {
        npp.MaNPP = Session["MaNPP"].ToString();
        npp.CT();
        npp.Sua_NgayHetHan();
    }
    protected void lbtViewMap_Click(object sender, EventArgs e)
    {
        if (Session["MaNPPClick"] == null)
        {
            npp.MaNPP = Session["MaNPP"].ToString();
            npp.CT();
        }
        else
        {
            npp.MaNPP = Session["MaNPPClick"].ToString();
            npp.CT();
        }
        //Code hiển thị bản đồ từ địa chỉ trên text box
        if (npp.MaDuongNPPLL == "0000" && (npp.SoNhaNPPLL == "..." || npp.SoNhaNPPLL == ""))
            btnShowMapfull_Click(sender, e);
        else
            if (npp.SoNhaNPPLL == "..." || npp.SoNhaNPPLL == "")
                btnShowMapNull_SN_Click(sender, e);
            else
                btnShowMap_Click(sender, e);
        lbtViewMap.Visible = false;
        GMap1.Visible = true;
    }
}