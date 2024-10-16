using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Mailer
{
    public interface IMailerService
    {
        public Task SendMailAsync(IMailObject mail, CancellationToken cancellationToken = default);
    }
}
