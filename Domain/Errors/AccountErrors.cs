using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Errors
{
    public static class AccountErrors
    {
        public static IError AccountAlreadyExist() => new Error("account already exists!", "404");

        public static IError AccountOrPassowrdError() => new Error("account or password is incorrect!","401");

    }
}
