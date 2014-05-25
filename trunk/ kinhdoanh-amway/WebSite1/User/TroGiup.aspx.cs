using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.ComponentModel;// for backgroundworker class
using System.Net;
using System.Threading;

public partial class User_TroGiup : System.Web.UI.Page
{
    BackgroundWorker bw;
    protected void Page_Load(object sender, EventArgs e)
    {
        bw = new BackgroundWorker();
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.WorkerSupportsCancellation = true;
        bw.WorkerReportsProgress = false;
    }
    public void SendMail()
    {
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("hunghuynh.it@gmail.com");
        msg.To.Add("manhhung.boy9x@gmail.com");
        msg.Body = "Testing the automatic mail";
        msg.IsBodyHtml = true;
        msg.Subject = "Movie Data";
        SmtpClient smt = new SmtpClient("smtp.gmail.com");
        smt.Port = 587;
        smt.Credentials = new NetworkCredential("hunghuynh.it@gmail.com", "hungcokute123");
        smt.EnableSsl = true;
        smt.Send(msg);
        string script = "<script>alert('Mail Sent Successfully');self.close();</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "sendMail", script);
    }
    public void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        SendMail();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime current_time = DateTime.Now;
        current_time = current_time.AddSeconds(10);
        Thread.Sleep(20);
        if (current_time == DateTime.Now)
        {
            bw.RunWorkerAsync();
        }
    }
}

