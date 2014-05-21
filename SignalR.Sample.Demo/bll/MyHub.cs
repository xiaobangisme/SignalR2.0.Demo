/**************************************************************** 
 *  作者：       黄晓柠 
 *  功能：       [Function]
 *  创建时间：   2013/11/12 13:58:50
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.AspNet.SignalR.Hosting;

namespace SignalR.Sample.Demo.Controllers
{
    [HubName("messageHub")]
    public class MyHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            //Clients.All.addMessage(name, message, DateTime.Now.ToString());
            #region Demo 
            INameValueCollection queryString = Context.Request.QueryString;
            HttpContextBase httpContext = Context.Request.GetHttpContext();
            string parameterValue = queryString["version"];
            string userName = Clients.Caller.userName;
            string computerName = Clients.Caller.computerName; 
            #endregion

            //Clients.All.addMessage(name, message, DateTime.Now.ToString());
            #region 该区域代码等效于上面
            IClientProxy proxy = Clients.All;
            //throw new ArgumentException("参数为空");
            proxy.Invoke("addMessage", name, message, DateTime.Now.ToString());
            #endregion 
        }
        public override Task OnConnected()
        {
            string connectionID = Context.ConnectionId;
            INameValueCollection headers = Context.Request.Headers;
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            string connectionID = Context.ConnectionId;
            return base.OnReconnected();
        }
        public override Task OnDisconnected()
        {
            string connectionID = Context.ConnectionId;
            return base.OnDisconnected();
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            try
            {
                await Groups.Remove(Context.ConnectionId, groupName);
            }
            catch (TaskCanceledException e)
            {

            }
        }
        public void SendMessage()
        {
            if (true)
            {
                
            }
        }

    }
}