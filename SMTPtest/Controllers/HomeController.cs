using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMTPtest.DAL;
using SMTPtest.Models;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SMTPtest.Controllers
{
    public class HomeController : Controller
    {
        private SMTPtestContext db = new SMTPtestContext();

        public ActionResult Index()
        {
            List<User> userList = db.Users.ToList();

            List<SelectListItem> dropdown = new List<SelectListItem>();

            foreach (User u in userList)
            {
                dropdown.Add(new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.UserID.ToString()
                });
            }

            ViewBag.dropdown = dropdown;

            return View();
        }

        [HttpPost]
        public ActionResult SendText(FormCollection form)
        {
            String body = form["TextBody"];
            int toID = Int32.Parse(form["To"]);

            User toUser = db.Users.Find(toID);
            String to = toUser.Phone + toUser.Carrier;

            var message = new MailMessage();
            message.To.Add(new MailAddress(to));  // replace with valid value 
            message.From = new MailAddress("danielrferolino@gmail.com", "Daniel Ferolino");  // replace with valid value
            message.Subject = "Test Subject";
            message.Body = string.Format(body);
            message.IsBodyHtml = false;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "danielrferolino@gmail.com",
                    Password = "*************"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

                return RedirectToAction("Index");
        }
    }
}