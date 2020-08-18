using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EmailCheckCheckche
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Booting up...");

            // List of negative keywords to look for
            var negatives = new List<string>();
            negatives.Add("rejected");
            negatives.Add("other applicants");
            negatives.Add("not be able to");
            negatives.Add("no longer available");
            negatives.Add("you have not been selected");
            negatives.Add("Unfortunately, at this time");
            negatives.Add("we have decided to pursue other candidates.");
            negatives.Add("other candidates");
            negatives.Add("position is no longer available");
            negatives.Add("Unfortunately, you are not the right fit");
            negatives.Add("sorry");
            negatives.Add("regretfully");
            negatives.Add("regret");
            negatives.Add("won&#39;t");
            negatives.Add("won't");
            negatives.Add("decided not");
            negatives.Add("will not");
            negatives.Add("don't meet");

            // Create a simple mail repository using Gmail
            var mailRepository = new MailRepository(
                        "imap.gmail.com",
                        993,
                        true,
                        "xxxx@gmail.com",
                        "password"
                    );
            // Use self-written Email-Check Library
            EmailCheckCheckChe.Core.Mail checker = new EmailCheckCheckChe.Core.Mail();

            Console.WriteLine("Launched! Actively listening for emails.");

            // Continually listen for emails
            while (true)
            {
                // Sleep to rest the CPU
                System.Threading.Thread.Sleep(1000);

                // Grab all unread emails in inbox
                var emailList = mailRepository.GetUnreadMails("inbox");

                // Go through each unread email and check for negative keywords
                foreach (ActiveUp.Net.Mail.Message email in emailList)
                {
                    // If a negative keyword is found, initiate a response.
                    if (!checker.CheckMail(email, negatives))
                    {
                        // Send email to phone and personal email
                        List<string> to = new List<string>() { "xxxx@vtext.com", "xxxx@gmail.com" };
                        // Inform self of rejection
                        checker.CreateRejectionMail(to, "xxxx@gmail.com", "password", email);
                        // Reply to company for reflection
                        checker.ReplyMail("xxxx@gmail.com", "password", email);
                    }
                }
            }
        }
    }
}
