using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionError.AccountUnion
{
    [UnionType]
    public interface RefreshTokenError : BaseUnionError
    {
    }
}
