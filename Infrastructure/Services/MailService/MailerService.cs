﻿using Domain.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MailService
{
    public  class MailerService : IMailerService
    {
        private readonly IOptionsMonitor<MailOption> _options;

        public MailerService(IOptionsMonitor<MailOption> options)
        {
            _options = options;
        }

        public async Task SendMailAsync(MailObject mail, CancellationToken cancellationToken = default)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("anpham", "anpham2112003@gmail.com"));

                message.To.Add(new MailboxAddress("", mail.To));

                message.Subject = mail.Subject;

                var body = new BodyBuilder();

                body.HtmlBody = mail.Body;

                message.Body = body.ToMessageBody();

                Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

                using (var smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync(_options.CurrentValue.Host, _options.CurrentValue.Port, false, cancellationToken);

                    await smtp.AuthenticateAsync(_options.CurrentValue.Account, _options.CurrentValue.Password, cancellationToken);

                    await smtp.SendAsync(message);

                    Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

                    await smtp.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {

                throw;
            }

           
        }
    }
}
