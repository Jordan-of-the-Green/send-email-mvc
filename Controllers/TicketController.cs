using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVCSendEmail.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // Send email using SmtpClient
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    // Configure the SMTP client settings
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("Your Gmail Account", "Add Generated Password");

                    // Create the email message
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("Your Gmail Account");
                    mailMessage.To.Add(ticket.Email);
                    mailMessage.Subject = "Ticket Information";
                    mailMessage.Body = $"Name: {ticket.Name}\nModule Code: {ticket.ModuleCode}\nDescription: {ticket.Description}";

                    // Send the email
                    smtpClient.Send(mailMessage);
                }

                return RedirectToAction("Create", "Ticket");
            }

            return View(ticket);
        }
    }
}
