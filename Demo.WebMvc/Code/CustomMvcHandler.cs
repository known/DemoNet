using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.WebMvc.Code
{
    public class CustomMvcHandler : MvcHandler
    {
        public CustomMvcHandler(RequestContext requestContext)
            : base(requestContext)
        {
        }

        protected override void ProcessRequest(HttpContext httpContext)
        {
            try
            {
                base.ProcessRequest(httpContext);
            }
            catch (Exception exc)
            {
                throw new ApplicationException("RouteUsed:" +
                       RequestContext.RouteData.Route.GetVirtualPath(
                        RequestContext, RequestContext.RouteData.Values), exc);
            }
        }
    }
}