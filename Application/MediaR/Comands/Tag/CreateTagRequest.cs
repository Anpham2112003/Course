﻿using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Tag;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Tag
{
    public class CreateTagRequest:IRequest<MutationPayload<CreateTagRequest,CreateTagError>>,IRequireValidation
    {
        public string? Name { get; set; }
    }
}
