using Evanto.DAL.Context;

namespace Evanto.BL.Operations.RoleOperations
{
    public class UpdateRoleOperation : Operation<UpdateRoleInput,UpdateRoleOutput>
    {
        public override void DoExecute()
        {
            UpdateRoleOutput result = new  UpdateRoleOutput();
            var role = Uow.GetRepository<Role>().GetById(Parameters.Id);
             role = Mapper.Map(this.Parameters, role);
            this.Uow.GetRepository<Role>().Update(role);
            this.Uow.SaveChanges(); 
            result.IsUpdated = true;
            Result.Output = result;
        }
    }
}
