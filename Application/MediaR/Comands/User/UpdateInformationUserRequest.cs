﻿using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.User;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class UpdateInformationUserRequest : IRequest<MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>>, IRequireValidation
    {
        public Guid Id { get; set; }
        public string? Information { get; set; }
    }
}
