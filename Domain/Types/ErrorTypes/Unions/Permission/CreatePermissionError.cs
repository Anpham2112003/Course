using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Unions.Permission
{
    [UnionType]
    public interface CreatePermissionError:BaseUnionError
    {
    }
}
