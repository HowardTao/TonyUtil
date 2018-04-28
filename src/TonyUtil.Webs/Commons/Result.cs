using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TonyUtil.Webs.Commons
{
   public class Result:JsonResult
   {
        /// <summary>
        /// 状态码
        /// </summary>
       private readonly StateCode _code;
        /// <summary>
        /// 消息
        /// </summary>
       private readonly string _message;
        /// <summary>
        /// 数据
        /// </summary>
       private readonly dynamic _data;
        public Result(StateCode code,string message,dynamic data=null) : base(null)
        {
            _code = code;
            _message = message;
            _data = data;
        }

       public override Task ExecuteResultAsync(ActionContext context)
       {
           Value = new
           {
               Code = _code.Value(),
               Message = _message,
               Data = _data
           };
           return base.ExecuteResultAsync(context);
       }
   }
}
