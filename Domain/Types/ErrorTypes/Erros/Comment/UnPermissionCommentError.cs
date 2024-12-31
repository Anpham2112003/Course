using Domain.Types.ErrorTypes.Unions.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Comment
{
    public class UnPermissionCommentError : CreateCommentError,UpdateCommentError,DeleteCommentError
    {
        public string? code { get; set; }=nameof(UnPermissionCommentError);
        public string? message { get; set; } = "You have not permission!";
    }
}
