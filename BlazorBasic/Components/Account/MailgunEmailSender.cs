
using BlazorBasic.Data;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;

namespace BlazorBasic.Components.Account
{
    public class MailgunEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IFluentEmail _fluentEmail;

        public MailgunEmailSender(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            var subject = "Confirm your email";
            var message = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.";
            await SendEmailAsync(email, subject, message);
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            var subject = "Reset your password";
            var message = $"Please reset your password by <a href='{resetLink}'>clicking here</a>.";
            await SendEmailAsync(email, subject, message);
        }

        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            var subject = "Reset your password";
            var message = $"Please reset your password using the following code: {resetCode}";
            await SendEmailAsync(email, subject, message);
        }

        private async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            await _fluentEmail
                .To(toEmail)
                .Subject(subject)
                .Body(message, isHtml: true)
                .SendAsync();
        }
    }
}
