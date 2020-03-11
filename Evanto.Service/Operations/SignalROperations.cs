using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.UserOperations;
using Evanto.Service.Hubs;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Service.Operations
{
    public static class SignalROperations 
    {
        static IHubContext hubContext;
        static SignalROperations()
        {
            hubContext = GlobalHost.ConnectionManager.GetHubContext<ServiceHub>();
        }
        public static void BroadcastChangedBookingStatus(int bookingId, int statusId, int currentUserId)
        {
            var connectionsOperation = new GetConnectionIdsOperation();
            var connOpResult = connectionsOperation.Execute(new GetConnectionIdsInput
            {
                UserId = currentUserId
            });
            var signalROutput = JsonConvert.SerializeObject(new ChangeBookingStatusSignalROutput
            {
                BookingId = bookingId,
                StatusId = statusId
            });

            if (connOpResult.IsSuccess)
            {
                connOpResult.Output.ConnectionIds.ForEach(connId =>
                {
                    hubContext.Clients.Client(connId).sendClient(signalROutput);
                });
            }
        }
    }
}
