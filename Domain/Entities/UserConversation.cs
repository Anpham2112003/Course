﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserConversation
    {
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }
    }
}
