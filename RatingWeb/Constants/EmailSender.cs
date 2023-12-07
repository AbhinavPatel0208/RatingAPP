using Microsoft.AspNetCore.Identity.UI.Services;

namespace RatingWeb.Constants
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Logic To Send Email
            return Task.CompletedTask;
        }
    }
}
