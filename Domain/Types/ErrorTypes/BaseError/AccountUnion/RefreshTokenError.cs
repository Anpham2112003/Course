using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Types.ErrorTypes.BaseError;

namespace Domain.Types.ErrorTypes.BaseError.AccountUnion
{
    [UnionType]
    public interface RefreshTokenError : BaseUnionError
    {
    }
}
