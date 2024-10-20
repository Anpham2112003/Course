using Domain.Types.ErrorTypes.BaseError.UserUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.UserErors
{
    public class UserNotPermissionError : UpdateProfileUserError, UpdateInformationUserError,UploadAvatarUserError,DeleteAvatarUserError
    {
        public string? code { get; set; } = nameof(UserNotPermissionError);
        public string? message { get; set; } = "You have not permission!";
    }
}
