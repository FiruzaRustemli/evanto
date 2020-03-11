using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.RoleOperations
{
    public class CreateRoleOperation : Operation<CreateRoleInput,CreateRoleOutput>
    {
        public override void DoExecute()
        {
            CreateRoleOutput result = new CreateRoleOutput();
            var oldrole = Uow.GetRepository<Role>().GetById(Parameters.Id);
            if (oldrole==null)
            {
                Role role = Mapper.Map<CreateRoleInput, Role>(this.Parameters);
                this.Uow.GetRepository<Role>().Add(role);
                this.Uow.SaveChanges();
                result.IsCreated = true;
            }
            else
            {
                result.IsCreated = false;
                Result.ErrorList.Add(new Error
                {
                    Type = OperationResultCode.Exception,
                    Text = "Id is exsist",
                    Code = "400"
                });
            }
            Result.Output = result;
        }
    }
}
