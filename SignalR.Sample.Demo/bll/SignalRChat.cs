using Microsoft.AspNet.SignalR;
/**************************************************************** 
 *  作者：       黄晓柠 
 *  功能：       [Function]
 *  创建时间：   2013/11/12 15:49:38
 ***************************************************************/
using Microsoft.Owin;
using Owin;
using SignalR.Sample.Demo.bll;
using SignalR.Sample.Demo.Controllers;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(typeof(MyHub), () => new MyHub());//注入
            GlobalHost.HubPipeline.AddModule(new ErrorHubPipelineModule()); 
            app.MapSignalR();
        }
    }
}