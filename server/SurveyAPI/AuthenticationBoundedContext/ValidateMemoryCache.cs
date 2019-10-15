
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBoundedContext
{
    /// <summary>
    /// Validate Memory Cache and Claims.
    /// </summary>
    public class ValidateMemoryCache : AuthorizationHandler<ValidateMemoryCache>, IAuthorizationRequirement
    {
        private const string SYSTEM_NAME = "systemName";
        private const string ENTERPRISE_ID = "enterpriseId";
        private const string ENTERPRISE_ID_OR_NAME = "enterpriseIdOrName";
        private const string AUTHORIZATION = "Authorization";
        private const string ENTERPRISE = "enterprise";
        private const string ROLES = "roles";

        /// <summary>
        /// Handle the memory cache validation
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidateMemoryCache requirement)
        {
            try
            {
                if (context.Resource is Endpoint endpoint)
                {
                    // Read Authorization Token.
                    //string authorizationHeader = ReadAuthorization(endpoint.Metadata.OfType<IFilterMetadata>());

                    //string[] authorizationHeaderParts = authorizationHeader.Split(' ');
                    //string tokenString = authorizationHeaderParts.Length > 1 ? authorizationHeaderParts[1] : string.Empty;
                    //if (!string.IsNullOrWhiteSpace(tokenString))
                    //{
                    //    JwtSecurityToken token = new JwtSecurityToken(tokenString);

                    //    if (token != null)
                    //    {
                    //        IMemoryCache memoryCache = filterContext.HttpContext.RequestServices.GetService<IMemoryCache>();
                    //        if (memoryCache.TryGetValue(token.Id, out JwtSecurityToken cacheTokenEntry))
                    //        {
                    //            // There could be chances that the Token is still in cache but token validity
                    //            // is expired. In that case we need to ask user to re-authenticate.
                    //            if (cacheTokenEntry.ValidTo.CompareTo(DateTime.Now.ToUniversalTime()) < 0)
                    //            {
                    //                context.Fail();
                    //                return Task.CompletedTask;
                    //            }
                    //            string enterpriseIdFromToken = null, enterpriseFromToken = null, rolesFromToken = null;

                    //            // Extract the token claim values
                    //            foreach (var item in token.Claims)
                    //            {
                    //                if (item.Type == ENTERPRISE_ID)
                    //                {
                    //                    enterpriseIdFromToken = item.Value;
                    //                }
                    //                else if (item.Type == ENTERPRISE)
                    //                {
                    //                    enterpriseFromToken = item.Value;
                    //                }
                    //                else if (item.Type == ROLES)
                    //                {
                    //                    rolesFromToken = item.Value;
                    //                }
                    //            }

                    //            // Validate User's Role against to this policy handler.
                    //            // NOTE: This is a workaround for scenarios where the header-based JWT Token Authentication scheme is insufficient.
                    //            if (ValidateRole(rolesFromToken) == false)
                    //            {
                    //                // Role was not validated.
                    //                context.Fail();
                    //            }

                    //            // This condition is for partner. They have all rights
                    //            if (!string.IsNullOrEmpty(rolesFromToken) && string.Equals(rolesFromToken, SecurityRoles.PARTNER_ADMIN))
                    //            {
                    //                context.Succeed(requirement);
                    //                return Task.CompletedTask; // It's a parter flow
                    //            }

                    //            // TODO -  Use ASP.net core Resource filters. 
                    //            // Check if ENTERPRISE_ID_OR_NAME matches with the token's EnterpriseID or EnterpriseName
                    //            if (string.Equals(filterContext.ActionDescriptor.RouteValues["controller"], ENTERPRISE, StringComparison.InvariantCultureIgnoreCase))
                    //            {
                    //                // Some API's in Enterprise does not have ENTERPRISE_ID_OR_NAME as a route
                    //                if (filterContext.RouteData.Values.ContainsKey(ENTERPRISE_ID_OR_NAME))
                    //                {
                    //                    string enterpriseIdorName = filterContext.RouteData.Values[ENTERPRISE_ID_OR_NAME] as string;

                    //                    if (string.Equals(enterpriseIdFromToken, enterpriseIdorName, StringComparison.InvariantCultureIgnoreCase))
                    //                    {
                    //                        // Allow it to go with further validation
                    //                    }
                    //                    else if (string.Equals(enterpriseFromToken, enterpriseIdorName, StringComparison.InvariantCultureIgnoreCase))
                    //                    {
                    //                        // Allow it to go with further validation
                    //                    }
                    //                    else
                    //                    {
                    //                        context.Fail();
                    //                    }
                    //                }
                    //            }

                    //            // If Route parameter contains enterpriseId, then compare against claim if available. If matches, then succeed.
                    //            var enterpriseId = filterContext.RouteData.Values[ENTERPRISE_ID];

                    //            if (enterpriseId != null)
                    //            {
                    //                if (enterpriseIdFromToken == enterpriseId.ToString())
                    //                {
                    //                    context.Succeed(requirement);
                    //                }
                    //                else
                    //                {
                    //                    // Claim was found but did not match the Route value, hence suspicious.
                    //                    context.Fail();
                    //                }
                    //            }
                    //            else
                    //            {
                    //                // Here also do validation to understand if the token is having enterprise and/or enterpriseId.
                    //                // If so then succeed only on match else fail.
                    //                // Get enterpriseId from systemName (Available in query string of each request)
                    //                // Compare with the claim enterpriseId

                    //                if (filterContext.HttpContext.Request.QueryString.HasValue)
                    //                {
                    //                    string systemName = HttpUtility.ParseQueryString(filterContext.HttpContext.Request.QueryString.Value).Get(SYSTEM_NAME);
                    //                    if (!string.IsNullOrEmpty(systemName))
                    //                    {
                    //                        ITenantService tenantService = filterContext.HttpContext.RequestServices.GetService<ITenantService>();
                    //                        EPS.Environment environmentDetails = tenantService.GetEnvironment(enterpriseFromToken, systemName);

                    //                        if (environmentDetails != null)
                    //                        {
                    //                            if (string.Equals(Utility.ConvertIdBinaryToBase64String(environmentDetails.Enterprise_ID), enterpriseIdFromToken))
                    //                            {
                    //                                context.Succeed(requirement);
                    //                            }
                    //                            else
                    //                            {
                    //                                // Claim was found but did not match the users enterprise value, hence suspicious.
                    //                                context.Fail();
                    //                            }
                    //                        }
                    //                        else
                    //                        {
                    //                            // Could nto retrieve the record from DB. Might be because it's not existing or it's malicious request
                    //                            context.Fail();
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        // Neither route contains enterpriseId nor the URL contains systemName. 
                    //                        // Not hackable instance(Probabily) as parameters are passed via body and body is SSL encrypted.
                    //                        context.Succeed(requirement);
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    context.Succeed(requirement);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            context.Fail();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        context.Fail();
                    //    }
                    //}
                    //else
                    //{
                    //    context.Fail();
                    //}
                }
                else
                {
                    context.Fail();
                }

                return Task.CompletedTask;
            }
            catch (Exception)
            {
                // TODO - Log the error and fail the task as now DB is involved 
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Read Authorization.
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        //protected virtual string ReadAuthorization(AuthorizationFilterContext filterContext)
        //{
        //    // Read Header "Authorization" field for token.
        //    string authorizationHeader = filterContext.HttpContext.Request.Headers[AUTHORIZATION].ToString();

        //    // Read Form "Authorization" field for token.
        //    // NOTE: This is to support file uploads, which cannot submit an authorization header.
        //    if (string.IsNullOrEmpty(authorizationHeader) && (filterContext.HttpContext.Request.HasFormContentType))
        //    {
        //        authorizationHeader = filterContext.HttpContext.Request.Form[AUTHORIZATION];
        //    }

        //    return authorizationHeader;
        //}

        /// <summary>
        /// Validate Role.
        /// </summary>
        /// <param name="role"></param>
        protected virtual bool ValidateRole(string role)
        {
            // Always accept.
            return true;
        }
    }
}
