using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationBoundedContext
{
    public static class SecurityRoles
    {
        /// <summary>
        /// Partner Admin, i.e. "0"
        /// </summary>
        public const String ADMINISTRATOR = "0";

        /// <summary>
        /// Enterprise Admin, i.e. "1"
        /// </summary>
        public const String MANAGER = "1";

        /// <summary>
        /// Both Enterprise and Partner Admin, i.e. "0, 1"
        /// </summary>
        public const String USER = "3";

        /// <summary>
        /// Policy for Memory cache validation i.e. "Policy"
        /// </summary>
        public const string POLICY = "ValidateMemoryCache";
    }
}
