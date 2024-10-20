using Domain.Types.ErrorTypes.BaseError.UserUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.UserErors
{
    public class AvatarHasDeleted : DeleteAvatarUserError
    {
        public string? code { get; set; }=nameof(AvatarHasDeleted);
        public string? message { get; set; } = "Avatar has been deleted!";
    }
}
