using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class GetUserEventByUserOperation : Operation<GetUserEventByUserInput, GetUserEventByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetUserEventByUserInput();

            GetUserEventByUserOutput byUserOutput = new GetUserEventByUserOutput();

            List<UserEvent> userEvents;

            IEnumerable<UserEvent> query = null;
            if (this.Parameters.Id != null)
            {
                query = this.Uow.EvantoContext.SearchUserEvent(
                   this.Parameters.Id,
                   this.Parameters.CurrentUserId,
                   null,
                   null,
                   null,
                   null)
                       .Where(e => e.Status);
            }

            if (!string.IsNullOrEmpty(Parameters.SearchText))
            {
                query = this.Uow.EvantoContext.UserEvent.Where(e => e.Name.Contains(Parameters.SearchText));
            }

            if (query == null)
            {
                query = this.Uow.EvantoContext.SearchUserEvent(
                 null,
                  this.Parameters.CurrentUserId,
                  null,
                  null,
                  null,
                  null)
                      .Where(e => e.Status);
            }

            userEvents = query.OrderByDescending(e => e.CreatedDate).ToList();

            byUserOutput.UserEvents = Mapper.Map<List<UserEvent>, List<UserEventUserDto>>(userEvents);
            Result.Output = byUserOutput;
        }
    }
}
