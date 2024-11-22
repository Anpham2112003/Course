using Domain.Types.ErrorTypes.Unions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.User
{
    public class UserNotFoundError : UpdateProfileUserError, UpdateInformationUserError
        , UploadAvatarUserError, DeleteAvatarUserError,GetUserError
    {
        public string? code { get; set; } = nameof(UserNotFoundError);
        public string? message { get; set; } = "User not found!";
    }
}
