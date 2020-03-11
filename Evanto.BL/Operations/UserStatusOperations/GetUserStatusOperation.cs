using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserStatusOperations
{
    public class GetUserstatusOperation : Operation<GetUserStatusInput, GetUserStatusOutput>
    {
        public override void DoExecute()
        {
            GetUserStatusOutput output = new GetUserStatusOutput {UserStatuses = new List<UserStatusDto>()};
            var predicate = PredicateBuilder.True<UserStatus>();
            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(p => p.Id == this.Parameters.Id);
            }
            if (!string.IsNullOrEmpty(this.Parameters.Name))
            {
                predicate = predicate.And(p => p.Name == this.Parameters.Name);
            }
            if (!string.IsNullOrEmpty(this.Parameters.Description))
            {
                predicate = predicate.And(p => p.Description == this.Parameters.Description);
            }


            var userStatuses = this.Uow.GetRepository<UserStatus>().GetAll(predicate)
                .ToList();
            output.UserStatuses = Mapper.Map<List<UserStatus>, List<UserStatusDto>>(userStatuses);
            Result.Output = output;
        }
    }
}
