using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;

namespace TempleDev_CapStone_Code
{
    public class Email
    {
        private MailMessage objMail = new MailMessage();
        private MailAddress toAddress;
        private MailAddress fromAddress;
        private MailAddress ccAddress;
        private MailAddress bccAddress;
        private String subject;
        private String messageBody;
        private Boolean isHTMLBody = true;
        private MailPriority priority = MailPriority.Normal;
        private String mailHost = "smtp.temple.edu";


        public void SendMail(String recipient, String sender, String body, String subject, String cc = "", String bcc = "")
        {
            try
            {
                this.Recipient = recipient;
                this.Sender = sender;
                this.Subject = subject;
                this.Message = body;
               
                //this.Message = "this is not a test";

                objMail.To.Add(this.toAddress);
                objMail.From = this.fromAddress;
                objMail.Subject = this.subject;
                objMail.Body = this.messageBody;
              
                //objMail.Body = "this is not a test";
                objMail.IsBodyHtml = this.isHTMLBody;
                objMail.Priority = this.priority;

                if (cc != null && !cc.Equals(String.Empty))
                {
                    this.CCAddress = cc;
                    objMail.CC.Add(this.ccAddress);
                }

                if (bcc != null && !bcc.Equals(String.Empty))
                {
                    this.BCCAddress = bcc;
                    objMail.Bcc.Add(this.bccAddress);
                }

                SmtpClient smtpMailClient = new SmtpClient(this.mailHost);
                smtpMailClient.Send(objMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean SendMail()
        {
            try
            {
                objMail.To.Add(this.toAddress);
                objMail.From = this.fromAddress;
                objMail.Subject = this.subject;
                objMail.Body = this.messageBody;
                objMail.IsBodyHtml = this.isHTMLBody;
                objMail.Priority = this.priority;

                if (!ccAddress.Equals(String.Empty))
                    objMail.CC.Add(this.ccAddress);

                if (!bccAddress.Equals(String.Empty))
                    objMail.Bcc.Add(this.bccAddress);

                SmtpClient smtpMailClient = new SmtpClient(this.mailHost);
                smtpMailClient.Send(objMail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public String Recipient
        {
            get { return this.toAddress.ToString(); }
            set { this.toAddress = new MailAddress(value); }
        }

        public String Sender
        {
            get { return this.fromAddress.ToString(); }
            set { this.fromAddress = new MailAddress(value); }
        }

        public String CCAddress
        {
            get { return this.ccAddress.ToString(); }
            set { this.ccAddress = new MailAddress(value); }
        }

        public String BCCAddress
        {
            get { return this.bccAddress.ToString(); }
            set { this.bccAddress = new MailAddress(value); }
        }

        public String Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        public String Message
        {
            get { return this.messageBody; }
            set { this.messageBody = value; }
        }

        public Boolean HTMLBody
        {
            get { return this.isHTMLBody; }
            set { this.isHTMLBody = value; }
        }

        public MailPriority Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }

        public String MailHost
        {
            get { return this.mailHost; }
            set { this.mailHost = value; }
        }

    }
}