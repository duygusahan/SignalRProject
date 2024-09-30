using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRProject.DtoLayer.MailDtos;
using System.Net.Mail;

namespace SignalRWebUi.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Yummy Rezarvasyon", "mail adresi");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",createMailDto.ReciverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;  

            mimeMessage.Body=bodyBuilder.ToMessageBody();
            mimeMessage.Subject=createMailDto.Subject;

            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com", 587, false);

            return RedirectToAction("Index", "Category");
        }
    }
}
