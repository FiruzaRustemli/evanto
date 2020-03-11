using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetEventAndBookingsCountByUserInput : OperationParameters
    {
    }
    public class GetEventAndBookingsCountByUserOutput
    {
        public int EventsCount { get; set; }
        public int ConfirmedBookingsCount { get; set; }
        public int RejectedBookingsCount { get; set; }
        public int WaitingBookingsCount { get; set; }
    }
}
