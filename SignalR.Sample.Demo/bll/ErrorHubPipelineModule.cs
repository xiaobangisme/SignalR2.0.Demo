using Microsoft.AspNet.SignalR.Hubs;
/**************************************************************** 
 *  作者：       黄晓柠 
 *  功能：       [Function]
 *  创建时间：   2013/11/13 11:35:04
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalR.Sample.Demo.bll
{
    public class ErrorHubPipelineModule : HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            Debug.Write(" = > 错误：" + exceptionContext.Error);
            base.OnIncomingError(exceptionContext, invokerContext);
        }
    }
}