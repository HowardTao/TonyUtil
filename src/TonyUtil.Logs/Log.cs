using System;
using System.Collections.Generic;
using System.Text;
using TonyUtil.Domains.Sessions;
using TonyUtil.Logs.Abstractions;
using TonyUtil.Logs.Contents;
using TonyUtil.Logs.Core;

namespace TonyUtil.Logs
{
   public class Log:LogBase<LogContent>
    {
        public Log(ILogProvider provider, ILogContent content, ISession session) : base(provider, content, session)
        {
        }

        protected override LogContent GetContent()
        {
            throw new NotImplementedException();
        }
    }
}
