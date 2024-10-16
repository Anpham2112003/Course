using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Untils;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class UploadAvatarUserRequest:IRequest<MutationPayload<string,UploadAvatarUserError>>
    {
        public Guid Id { get; set; }
        public IFormFile? File { get; set; }
    }
}
