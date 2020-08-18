using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EmailCheckCheckChe.Core
{
    public class Mail
    {

        // Function that checks the mail in the inbox
        public bool CheckMail(ActiveUp.Net.Mail.Message email, List<string> negatives)
        {
                // Show the email on the console
                Console.WriteLine("Name: {0}:" + "\n-------------------------------\n" +
                "Subject: " + "{1}" + "\n-------------------------------\n" +
                "{2}" + "\n-------------------------------\n", email.From, email.Subject, email.BodyHtml.Text);

                // Grab attachments as well
                if (email.Attachments.Count > 0)
                {
                    foreach (ActiveUp.Net.Mail.MimePart attachment in email.Attachments)
                    {
                        Console.WriteLine("<p>Attachment: {0} {1}</p>", attachment.ContentName, attachment.ContentType.MimeType);
                    }
                }

                // If a negative is found, return false which initiates the response/reject emails
                if (negatives.Any(email.BodyHtml.Text.ToLower().Contains))
                {
                    Console.WriteLine("Negative Email Found: Initiating Response Sequence");
                return false;
                }
            return true;
        }

        // Create a rejection email to send to self
        public void CreateRejectionMail(List<string> to, string from, string pass, ActiveUp.Net.Mail.Message email)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                foreach (var t in to)
                {
                    mail.To.Add(t);
                }
                mail.Subject = "REJECTED: " + email.Subject;
                mail.Body = "<h1>A negatively connotated keyword was found in this email.</h1>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        // Send a response to the company inquiring about things to improve on
        public void ReplyMail (string from, string pass, ActiveUp.Net.Mail.Message email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                string s = email.From.ToString();
                string[] to = s.Split('<', '>');
                mail.To.Add(to[1]);
                mail.Subject = "RE: " + email.Subject;
                mail.Body = "<p>Hello " + to[1] + ",<br></br><br></br>  Thanks for taking the time to review my resume. If possible, " +
                    "would you mind telling me some of the qualifications that the job required that I still need to work " +
                    "on? I greatly appreciate your feedback.<br></br><br></br> " +
                    "Thank you, <br></br> " + 
                    "Alexander Brewer</p>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

    }
}
