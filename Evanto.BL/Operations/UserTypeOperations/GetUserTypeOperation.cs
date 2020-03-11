using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserTypeOperations
{
    public class GetUserTypeOperation:Operation<GetUserTypeInput,GetUserTypeOutput>
    {
        public override void DoExecute()
        {
            GetUserTypeOutput output = new GetUserTypeOutput { UserTypes = new List<UserTypeDto>() };
            var predicate = PredicateBuilder.True<DAL.Context.UserType>();
            var userTypes = this.Uow.GetRepository<DAL.Context.UserType>().GetAll(predicate)
                .ToList();
            output.UserTypes = Mapper.Map<List<UserType>, List<UserTypeDto>>(userTypes);
            Result.Output = output;


        }
    }
}
