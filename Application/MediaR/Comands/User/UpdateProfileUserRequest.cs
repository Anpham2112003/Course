using Application.MediaR.Pipeline;
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
    public class UpdateProfileUserRequest : IRequest<MutationPayload<UpdateProfileUserRequest, UpdateProfileUserError>>, IRequireValidation
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }

    }
}
