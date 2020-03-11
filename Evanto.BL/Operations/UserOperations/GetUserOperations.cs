using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserOperations : Operation<GetUserInput, GetUserOutput>
    {
        public override void DoExecute()
        {
            GetUserOutput output = new GetUserOutput();
            var users = Uow.EvantoContext.SearchUser(Parameters.Id,
                    Parameters.Username,
                    Parameters.RegistrationDate,
                    Parameters.MaritalStatus,
                    Parameters.BirthDay,
                    Parameters.Type)
                .ToList();
            output.Users = Mapper.Map<List<User>, List<UserDto>>(users);
            Result.Output= output;
        }
    }
}
