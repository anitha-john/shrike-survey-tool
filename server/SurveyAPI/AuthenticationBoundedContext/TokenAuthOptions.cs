using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationBoundedContext
{
    public class TokenAuthOptions
    {

        /// <summary>
        /// Audience details for the token
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Issuer details for the token servicec.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Signing credentials for the token service.
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }
}
