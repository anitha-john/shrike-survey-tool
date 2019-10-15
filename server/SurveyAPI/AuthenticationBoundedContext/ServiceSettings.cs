
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationBoundedContext
{
    public class ServiceSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// For this time the token would be valid.
        /// </summary>
        /// <example> In Minutes</example>
        public int TokenLifetime { get; set; }

        /// <summary>
        /// For this time token session will be valid. Means if you continue to use
        /// the token for within this specified time, the session will continue to 
        /// be valid till TokenLifetime. This value should be smaller than the TokenLifetime.
        /// </summary>
        /// <example> In Minutes</example>
        public int SessionTimeout { get; set; }


        /// <summary>
        /// Pivotal Auth Service Url
        /// </summary>
        public string AuthServiceUrl { get; set; }


    }
}
