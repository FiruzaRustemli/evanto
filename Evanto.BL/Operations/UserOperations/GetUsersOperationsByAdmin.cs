using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUsersOperationsByAdmin : Operation<GetUsersInputByAdmin, GetUsersOutputByAdmin>
    {
        public override void DoExecute()
        {
            GetUsersOutputByAdmin output = new GetUsersOutputByAdmin();
            var users = this.Uow.EvantoContext.SearchUser(Parameters.Id,
                    Parameters.Username,
                    Parameters.RegistrationDate,
                    Parameters.MaritalStatus,
                    Parameters.BirthDay,
                    Parameters.Type)
                .ToList();
            output.Users = Mapper.Map<List<User>, List<UserAdminDto>>(users);
            Result.Output= output;
        }
    }
}
