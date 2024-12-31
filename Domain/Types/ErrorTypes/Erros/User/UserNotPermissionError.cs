using Domain.Types.ErrorTypes.Unions.Comment;
using Domain.Types.ErrorTypes.Unions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.User
{
    public class UserNotPermissionError : UpdateProfileUserError,
        UpdateInformationUserError, UploadAvatarUserError
        , DeleteAvatarUserError,CreateCommentError
    {
        public string? code { get; set; } = nameof(UserNotPermissionError);
        public string? message { get; set; } = "You have not permission!";
    }
}
