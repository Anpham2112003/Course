﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MailService
{
    public sealed class MailObject
    {
        public string? To { get; set; }
        public string? Subject {  get; set; }
        public string? Body { get; set; }

        public MailObject(string? to, string? subject, string? body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
