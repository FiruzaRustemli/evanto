using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.Client
{
    public class GetClientByClientIdOperation : Operation<GetClientByClientIdInput, GetClientByClientIdOutput>
    {
        public override void DoExecute()
        {
            GetClientByClientIdOutput output = new GetClientByClientIdOutput();

            Evanto.DAL.Context.Client client = this.Uow.GetRepository<Evanto.DAL.Context.Client>().Get(c => c.OAuthClientID == this.Parameters.ClientId);

            // Checks if the user is null or not
            if (client == null)
            {
                // Set error

                // Return
            }

            output.Client = Mapper.Map<Evanto.DAL.Context.Client, ClientDto>(client);

            Result.Output = output;
        }
    }
}
