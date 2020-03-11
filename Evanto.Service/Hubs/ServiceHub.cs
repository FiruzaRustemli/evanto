using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Evanto.BL.Operations.UserOperations;
using Microsoft.Owin;
using Evanto.Service.Extensions;
using System.Threading;
using Evanto.Service.Attributes;

namespace Evanto.Service.Hubs
{
    [HubName("serviceHub")]
    
    public class ServiceHub : Hub
    {
        public override Task OnConnected()
        {
            var operation = new CreateRealtimeConnectionOperation();
            CreateRealtimeConnectionInput parameters = new CreateRealtimeConnectionInput();
            parameters.ConnectionId = Context.ConnectionId;
            var userId = Context.Request.QueryString.Get("userId");
            parameters.UserId = int.Parse(userId);
            var opResult = operation.Execute(parameters.Authorized());
            if (!opResult.IsSuccess)
            {
                Clients.Caller.serverOrderedDisconnect();
            }
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var operation = new DeleteRealtimeConnectionOperation();
            var opResult = operation.Execute(new DeleteRealtimeConnectionInput
            {
                ConnectionId = Context.ConnectionId
            });
            return base.OnDisconnected(stopCalled);
        }
    }
}