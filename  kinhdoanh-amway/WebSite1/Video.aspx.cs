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
        }
    }
    //GooleMap tìm kiếm
    
  
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
}