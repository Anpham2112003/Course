using Domain.Types.ErrorTypes.BaseError.UserUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.UserErors
{
    public class UserNotFoundError : UpdateProfileUserError, UpdateInformationUserError,UploadAvatarUserError,DeleteAvatarUserError
    {
        public string? code { get; set; } = nameof(UserNotFoundError);
        public string? message { get; set; } = "User not found!";
    }
}
