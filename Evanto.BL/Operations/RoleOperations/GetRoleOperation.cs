using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.RoleOperations
{
    public class GetRoleOperation : Operation<GetRoleInput, GetRoleOutput>
    {
        public override void DoExecute()
        {
            GetRoleOutput output = new GetRoleOutput { Roles = new List<RoleDto>() };
            var predicate = PredicateBuilder.True<Role>();
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
            if (this.Parameters.Status != null)
            {
                predicate = predicate.And(p => p.Status == this.Parameters.Status);
            }

            var roles = this.Uow.GetRepository<Role>().GetAll(predicate).ToList();
            var returnedData = Mapper.Map<List<Role>, List<RoleDto>>(roles);
            foreach (RoleDto t in returnedData)
            {
                t.OldId = t.Id;
            }
            output.Roles = returnedData;
            Result.Output = output;
        }
    }
}
