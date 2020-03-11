using Evanto.DAL.Context;

namespace Evanto.BL.Operations.RoleOperations
{
    public class DeleteRoleOperation : Operation<DeleteRoleInput,DeleteRoleOutput>
    {
        public override void DoExecute()
        {
            DeleteRoleOutput result = new DeleteRoleOutput();
            Role role = this.Uow.GetRepository<Role>().GetById(this.Parameters.Id);
            this.Uow.GetRepository<Role>().Delete(role);
            result.IsDeleted = true;
            Result.Output = result;
        }
    }
}
