using Domain.Types.ErrorTypes.Unions.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Tag
{
    public class TagNameExistError : CreateTagError, UpdateTagError
    {
        public string? code { get; set; } = nameof(TagNameExistError);
        public string? message { get; set; } = "Tag name was Exist!";
    }
}
