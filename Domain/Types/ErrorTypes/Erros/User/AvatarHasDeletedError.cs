using Domain.Types.ErrorTypes.Unions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.User
{
    public class AvatarHasDeletedError : DeleteAvatarUserError
    {
        public string? code { get; set; } = nameof(AvatarHasDeletedError);
        public string? message { get; set; } = "Avatar has been deleted!";
    }
}
