using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp
{
    public class MvcHandleErrorAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> ExecptionQueue = new Queue<Exception>();
        /// <summary>
        /// 可以捕获异常数据
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            //写到错误处理队列
            ExecptionQueue.Enqueue(ex);
            //指定跳转到错误页面.如果不加，默认调整至Shared下的error.cshtml
            //filterContext.HttpContext.Response.Redirect("Error.html");
        }
    }
}