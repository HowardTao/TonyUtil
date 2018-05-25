using Exceptionless.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using TonyUtil.Webs.Commons;

namespace TonyUtil.Webs.Filters
{
    /// <summary>
    /// 异常处理过滤器
    /// </summary>
   public class ExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new Result(StateCode.Fail, context.Exception.GetMessage());
        }
    }
}
