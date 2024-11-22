using Domain.Types.ErrorTypes.Unions.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Tag
{
    public class TagNotFoundError : UpdateTagError, DeleteTagError
    {
        public string? code { get; set; } = nameof(TagNotFoundError);
        public string? message { get; set; } = "Tag not found!";
    }
}
