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
using System.Net.Mail;

public partial class Video : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.DoanhThu dthu = new webdoan.DoanhThu();
    webdoan.DaoTao dt = new webdoan.DaoTao();
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    webdoan.QuaTrinhCD qtcd = new webdoan.QuaTrinhCD();
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
            GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
            GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));
        }
    }
    //GooleMap tìm kiếm
    
    protected void btnShowMap_Click(object sender, EventArgs e)
        {
            string fulladdress = string.Format("{0}, {1}, {2}", txtStreet.Text, txtCity.Text, txtCountry.Text);
            string skey = ConfigurationManager.AppSettings["AIzaSyAtXBSFK5ZJmk8dDm3-Sfvo1_ulXjsWmyk"];
            GeoCode geocode;
            geocode = GMap1.getGeoCodeRequest(fulladdress);
            var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
            GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            var oMarker = new Subgurim.Controles.GMarker(glatlng);
            //GMap1.addGMarker(oMarker);
            GMap1.Add(oMarker);
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
                Session["MaCD"] = npp.MaCD;
                while (npp.SL_CatThe() > 0)
                {
                    if (npp.SL_NhaPhanPhoi(npp.NPP_CatThe()) == 0)
                    {
                        npp.MaNPP = npp.NPP_CatThe();
                        nppsd.MaNPP = npp.MaNPP;
                        nppsd.Xoa_DS();
                        npp.CT();
                        SendMail(npp.Email, npp.TenNPP);
                        Session["TenNPPChon"] = npp.TenNPP;
                        Session["MaNPPChon"] = npp.MaNPP;
                        npp.MaNPP = npp.MaNBT;
                        npp.CT();
                        SendMail1(npp.Email, npp.TenNPP, Session["TenNPPChon"].ToString());
                        npp.MaNPP = Session["MaNPPChon"].ToString();
                        npp.CT();
                        khsd.MaNPP = npp.MaNPP;
                        khsd.MaNPPMoi = npp.MaNBT;
                        khsd.Sua_NPP();
                        dthu.MaNPP = npp.MaNPP;
                        dthu.Xoa_DS();
                        dt.MaNPP = npp.MaNPP;
                        dt.Xoa_DS();
                        cs.MaNPP = npp.MaNPP;
                        cs.MaNPPMoi = npp.MaNBT;
                        cs.Sua_NPP();
                        qtcd.MaNPP = npp.MaNPP;
                        qtcd.Xoa_DS();
                        npp.Xoa();
                    }
                    else
                    {
                        npp.MaNPP = npp.NPP_CatThe();
                        npp.CT();
                        SendMail(npp.Email, npp.TenNPP);
                        Session["MaNPPChon1"] = npp.MaNPP;
                        Session["TenNPPChon1"] = npp.TenNPP;
                        npp.MaNPP = npp.MaNBT;
                        npp.CT();
                        SendMail1(npp.Email, npp.TenNPP, Session["TenNPPChon1"].ToString());
                        npp.MaNPP = Session["MaNPPChon1"].ToString();
                        npp.CT();
                        npp.Sua_NhaBaoTro();
                        nppsd.MaNPP = npp.MaNPP;
                        nppsd.Xoa_DS();
                        khsd.MaNPP = npp.MaNPP;
                        khsd.MaNPPMoi = npp.MaNBT;
                        khsd.Sua_NPP();
                        dthu.MaNPP = npp.MaNPP;
                        dthu.Xoa_DS();
                        dt.MaNPP = npp.MaNPP;
                        dt.Xoa_DS();
                        cs.MaNPP = npp.MaNPP;
                        cs.MaNPPMoi = npp.MaNBT;
                        cs.Sua_NPP();
                        qtcd.MaNPP = npp.MaNPP;
                        qtcd.Xoa_DS();
                        npp.Xoa();
                    }
                }
                while (npp.NPP_SL_GuiMail_SapHetHan() > 0)
                {                        
                        npp.MaNPP = npp.NPP_GuiMail_SapHetHan();
                        npp.Sua_TinhTrang();
                        npp.CT();
                        SapHetHan_SendMail(npp.Email, npp.TenNPP);
                        Session["TenNPPChon"] = npp.TenNPP;
                        Session["MaNPPChon"] = npp.MaNPP;
                        npp.MaNPP = npp.MaNBT;
                        npp.CT();
                        SapHetHan_SendMail1(npp.Email, npp.TenNPP, Session["TenNPPChon"].ToString());               
                }
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
    protected void SendMail(string email, string TenNPP)
    {
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("hunghuynh.it@gmail.com", "hungcokute123");
        SmtpServer.Port = 587;
        SmtpServer.Host = "smtp.gmail.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        try
        {
            mail.From = new MailAddress("Amway2u@gmail.com", "Hỗ trợ Amways Việt Nam", System.Text.Encoding.UTF8);
            mail.To.Add(email);
            //mail.To.Add(txtTo.Text);
            mail.Subject = "Về việc cắt Nhà phân phối";
            mail.Body = "Chào " + TenNPP + ", <br /> Đã quá 6 tháng kể từ ngày hết hạn thẻ, nhưng bạn vẫn chưa gia hạn lại thẻ. <br /> Theo quy định, chúng tôi đã tiến hành hủy bỏ thẻ của bạn. <br /> Để tiếp tục trở thành Nhà phân phối của Amways, xin mời bạn đăng ký lại thẻ. <br /> Cảm ơn bạn đã hợp tác suốt thời gian qua!";
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mail.ReplyTo = new MailAddress("yourmail@mail.com");
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
            //ResetFrom();
        }
        catch (Exception ex) { ex.Message.ToString(); }
    }
    protected void SapHetHan_SendMail(string email, string TenNPP)
    {
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("hunghuynh.it@gmail.com", "hungcokute123");
        SmtpServer.Port = 587;
        SmtpServer.Host = "smtp.gmail.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        try
        {
            mail.From = new MailAddress("Amway2u@gmail.com", "Hỗ trợ Amways Việt Nam", System.Text.Encoding.UTF8);
            mail.To.Add(email);
            //mail.To.Add(txtTo.Text);
            mail.Subject = "Cảnh báo sắp hết hạn thẻ phân phối";
            mail.Body = "Chào " + TenNPP + ", <br />Thẻ Nhà Phân Phối của bạn còn 5 ngày nữa là hết hạn. <br /> Chúng tôi gửi mail để bạn biết về điều này, để tiếp tục là Nhà Phân Phối của Amways, bạn cần đến trung tâm để gia hạn cho thẻ.<br /> Cảm ơn sự hợp tác của bạn!";
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mail.ReplyTo = new MailAddress("yourmail@mail.com");
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
            //ResetFrom();
        }
        catch (Exception ex) { ex.Message.ToString(); }
    }
    protected void SendMail1(string Email, string TenNPP, string TenNPPChon)
    {
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("hunghuynh.it@gmail.com", "hungcokute123");
        SmtpServer.Port = 587;
        SmtpServer.Host = "smtp.gmail.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        try
        {
            mail.From = new MailAddress("hunghuynh.it@gmail.com", "Hỗ trợ Amway Việt Nam", System.Text.Encoding.UTF8);
            mail.To.Add(Email);
            //mail.To.Add(txtTo.Text);
            mail.Subject = "Về việc cắt Nhà phân phối";
            mail.Body = "Chào " + TenNPP + ",<br /> Đã quá 6 tháng kể từ ngày hết hạn thẻ, nhưng " + TenNPPChon + " vẫn chưa gia hạn lại thẻ. <br />Theo quy định, chúng tôi đã tiến hành hủy bỏ thẻ của " + TenNPPChon + ".<br /> Cảm ơn bạn đã hợp tác suốt thời gian qua!";
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mail.ReplyTo = new MailAddress("yourmail@mail.com");
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
            //ResetFrom();
        }
        catch (Exception ex) { ex.Message.ToString(); }
    }
    protected void SapHetHan_SendMail1(string Email, string TenNPP, string TenNPPChon)
    {
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("hunghuynh.it@gmail.com", "hungcokute123");
        SmtpServer.Port = 587;
        SmtpServer.Host = "smtp.gmail.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        try
        {
            mail.From = new MailAddress("hunghuynh.it@gmail.com", "Hỗ trợ Amway Việt Nam", System.Text.Encoding.UTF8);
            mail.To.Add(Email);
            //mail.To.Add(txtTo.Text);
            mail.Subject = "Cảnh báo sắp hết hạn thẻ phân phối";
            mail.Body = "Chào " + TenNPP + ",<br /> Thẻ Nhà Phân Phối của " + TenNPPChon + ", tuyến dưới của bạn còn 5 ngày nữa là hết hạn. <br /> Chúng tôi gửi mail để bạn biết về điều này, để tiếp tục là Nhà Phân Phối của Amways, bạn hoặc " + TenNPPChon + " cần đến trung tâm để gia hạn cho thẻ.<br /> Cảm ơn sự hợp tác của bạn!";
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mail.ReplyTo = new MailAddress("yourmail@mail.com");
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
            //ResetFrom();
        }
        catch (Exception ex) { ex.Message.ToString(); }
    }
    //Dưới đây là code trợ giúp
    protected void btnSend_Click(object sender, EventArgs e)
    {
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("hunghuynh.it@gmail.com", "hungcokute123");
        SmtpServer.Port = 587;
        SmtpServer.Host = "smtp.gmail.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();


        try
        {
            mail.From = new MailAddress(txtEmail.Text, txtHoTen.Text + " gửi từ form liên hệ", System.Text.Encoding.UTF8);
            mail.To.Add("hunghuynh.it@gmail.com");
            mail.Subject = "Mail từ Form liên";
            mail.Body = MailBody();
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mail.ReplyTo = new MailAddress("yourmail@mail.com");
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
            lblTB.Text = "Cảm ơn bạn đã gửi thông điệp đến website";
            ResetFrom();
        }
        catch (Exception ex) { Label1.Text = ex.Message.ToString(); }
    }
    private void ResetFrom()
    {
        txtHoTen.Text = "";
        txtDiaChi.Text = "";
        txtDienThoai.Text = "";
        txtEmail.Text = "";
        txtNoiDung.Text = "";
    }


    private string MailBody()
    {
        string strHTML = "";
        strHTML += "Họ và tên: " + txtHoTen.Text + "<br>";
        strHTML += "Địa chỉ: " + txtDiaChi.Text + "<br>";
        strHTML += "Điện thoại: " + txtDienThoai.Text + "<br>";
        strHTML += "Email: " + txtEmail.Text + "<br>";
        strHTML += "Đã gửi qua Form liên hệ với thông điệp:<br><b>";
        strHTML += txtNoiDung.Text + "</b>";
        return strHTML;
    }
}