using AuthenticationBoundedContext;
using CreationSharingBoundedContext;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using RepositoryFactory;
using ResponseBoundedContext;
using SurveyAPI.Controllers;
using SurveyAPI.Models;
using SurveyContext;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Web.Http;
using Unity;
using Unity.WebApi;


namespace SurveyAPI
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            RSAParameters keyParams = RSAKeyUtils.GetRandomKey();

            // Create the key, and a set of token options to record signing credentials 
            // using that key, along with the other parameters we will need in the 
            // token controlller.
            var key = new RsaSecurityKey(keyParams);
            TokenAuthOptions tokenOptions = new TokenAuthOptions()
            {
                Audience = ConfigurationManager.AppSettings["SiteUrl"],
                Issuer = ConfigurationManager.AppSettings["SiteUrl"],
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature)
            };

            container.RegisterInstance<TokenAuthOptions>(tokenOptions);

            IMemoryCache memorycache = new MemoryCache(new MemoryCacheOptions());
            container.RegisterInstance<IMemoryCache>(memorycache);

          

            Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions op = new Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions();
            op.AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active;
            op.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = key,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                // For development purpose ClockSkew is set to zero to respect the token validity lifetime set in config. 
                // Token expiration time = Issue time + expiration time in config + ClockSkew
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidIssuer = tokenOptions.Issuer
            };

            container.RegisterInstance<Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions>(op);

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ISurveyQuestions, SurveyQuestionsAggregateRoot>();
			container.RegisterType<ISurveyRoot, SurveyRoot>();
			container.RegisterType<ICreationRepository, CreationRepository>();
			container.RegisterType<ISurveyRepository, SurveyRepository>();
			container.RegisterType<ISurveyContextAggregator, SurveyContextAggregator>();
			container.RegisterType<ISurveyResponse, SurveyResponse>();
			container.RegisterType<ISurveyResponseRepository, SurveyResponseRepository>();
			container.RegisterType<IAuthenticate, Authenticate>();
			container.RegisterType<IAuthorisationRepository, AuthorisationRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

		}
	}
}