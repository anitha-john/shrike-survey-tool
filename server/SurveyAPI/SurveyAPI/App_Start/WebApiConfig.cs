using AuthenticationBoundedContext;
using CreationSharingBoundedContext;
using Dapper.FluentMap;
using Microsoft.IdentityModel.Tokens;
using Models;
using RepositoryFactory;
using SurveyAPI.Controllers;
using SurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Http;
using Unity;

namespace SurveyAPI
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            FluentMapper.Initialize(conf =>
            {
                conf.AddMap(new QuestionsMap());
                conf.AddMap(new SurveyMap());
                conf.AddMap(new SurveyResponseModelMap());
                conf.AddMap(new UserMap());
            });

           
            


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
