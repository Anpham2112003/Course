﻿using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class UploadAvatarUserRequest:IRequest<MutationPayload<string,UploadAvatarUserError>>
    {
        [GraphQLType(typeof(StringType))]
        public Guid Id { get; set; }

        [GraphQLType(typeof(UploadType))]   
        public IFile? File { get; set; }
    }
}
