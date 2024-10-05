using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MailService
{
    public interface IMailerService
    {
        public Task SendMailAsync(MailObject mail,CancellationToken cancellationToken=default);
    }
}
