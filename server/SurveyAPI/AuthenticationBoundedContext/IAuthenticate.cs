using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationBoundedContext
{
    public interface IAuthenticate
    {
        bool ValidLogin(object user);

        bool InvalidLogin(object user);
    }
}
