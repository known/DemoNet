using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Demo.WebMvc.Code;

namespace Demo.WebMvc
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //var myRoute = new Route("{controller}/{action}/{id}", new CustomRouteHandler());
            //RouteTable.Routes.Add("MyRoute", myRoute);

            RouteTable.Routes.MapRoute(
                "Default",                                                                      //路由名称
                "{controller}/{action}/{id}",                                                   //带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },      //参数默认值
                new string[] { "Sardf.Web.Controllers" }
            ).RouteHandler = new CustomRouteHandler(); ;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}