using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationBoundedContext
{
    public class Authenticate : IAuthenticate
    {
        public bool ValidLogin(object user)
        {
            return true;
        }

        public bool InvalidLogin(object user)
        {
            return false;
        }


    }
}
