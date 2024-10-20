using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class DeleteAvatarUserRequest:IRequest<MutationPayload<string,DeleteAvatarUserError>>
    {
        public Guid Id { get; set; }

    }
}
