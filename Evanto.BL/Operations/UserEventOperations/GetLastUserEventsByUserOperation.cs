using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class GetLastUserEventsByUserOperation : Operation<GetLastUserEventsByUserInput, GetLastUserEventsByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetLastUserEventsByUserInput();

            GetLastUserEventsByUserOutput byUserOutput = new GetLastUserEventsByUserOutput();
            var userEvents = this.Uow.EvantoContext.SearchUserEvent(
                null,
                this.Parameters.CurrentUserId,
                null,
                null,
                null,
                null)
                    .Where(e => e.Status).OrderByDescending(e => e.CreatedDate).Take(5).ToList();
            byUserOutput.UserEvents = Mapper.Map<List<UserEvent>, List<UserEventUserDto>>(userEvents);


            Result.Output = byUserOutput;
        }
    }
}
