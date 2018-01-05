using Demo.Web.Html5;
using System;
using System.Threading;
using System.Web.Mvc;

namespace Demo.WebMvc.Controllers
{
    public class Html5Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void WsTask()
        {
            HttpContext.AcceptWebSocketRequest(ctx =>
            {
                int.TryParse(ctx.QueryString["count"], out int count);
                return WebSocketManager.RunTask(ctx, wsm =>
                {
                    for (int i = 0; i < count; i++)
                    {
                        var message = string.Format("{0:00} {1:yyyy-MM-dd HH:mm:ss}", i + 1, DateTime.Now);
                        wsm.SendMessageAsync(message);
                        Thread.Sleep(1000);
                    }
                });
            });
        }
    }
}