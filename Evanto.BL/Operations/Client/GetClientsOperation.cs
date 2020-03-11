using Evanto.BL.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.Client
{
    public class GetClientsOperation : Operation<GetClientsInput, GetClientsOutput>
    {
        public override void DoExecute()
        {
            GetClientsOutput output = new GetClientsOutput();

            List<Evanto.DAL.Context.Client> clients = this.Uow.GetRepository<Evanto.DAL.Context.Client>().GetAll(c => c.StatusId == 1).ToList<Evanto.DAL.Context.Client>();

            // Checks if the user is null or not
            if (clients == null)
            {
                // Set error
                // Return
            }

            output.Clients = Mapper.Map<List<DAL.Context.Client>, List<ClientDto>>(clients);

            Result.Output = output;
        }
    }
}