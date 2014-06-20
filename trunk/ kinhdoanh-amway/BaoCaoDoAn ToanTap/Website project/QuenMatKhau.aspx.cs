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

public partial class QuenMatKhau : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btDoiMatKhau_Click(object sender, EventArgs e)
    {
        if ((string.IsNullOrWhiteSpace(txtMaNPP.Text) == false) && (string.IsNullOrWhiteSpace(txtMaNBT.Text) == false))
        {
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };

            string[] arr = allowedChars.Split(sep);

            string passwordString = "";

            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(9); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            npp.MatKhauMoi = passwordString;
            npp.MaNPP = txtMaNPP.Text;
            npp.CT();
            if (npp.MaNBT == txtMaNBT.Text)
            {
                npp.Reset_MatKhau();
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
                SendMail(npp.Email, npp.TenNPP, passwordString);
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Mã ADA của nhà bảo trợ không đúng.";
            }
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập mã ADA của bạn hoặc mã ADA của nhà bảo trợ.";
        }
    }
    protected void SendMail(string email, string TenNPP, string MatKhauMoi)
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
            mail.Subject = "Về việc quên mật khẩu";
            mail.Body = "Chào " + TenNPP + ", <br /> Bạn vừa yêu cầu website cấp lại mật khẩu cho tài khoản của bạn. <br /> Dưới đây là mật khẩu mới mà website cấp lại. <br /> <b>" + MatKhauMoi +  "</b> <br /> Vui lòng đổi mật khẩu sau khi đăng nhập vào hệ thống. <br /> Chúc bạn sức khỏe và hạnh phúc!";
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mail.ReplyTo = new MailAddress("yourmail@mail.com");
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
            //ResetFrom();
        }
        catch (Exception ex) { ex.Message.ToString(); }
    }
}