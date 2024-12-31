using Domain.Types.ErrorTypes.Unions.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Comment
{
    public class CommentNotFoundError : CreateCommentError,UpdateCommentError,DeleteCommentError
    {
        public string? code { get; set; }=nameof(CommentNotFoundError);
        public string? message { get; set; } = "Comment not found!";
    }
}
