using Evanto.Utils;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.Client
{
    public class ClientValidationOperation : Operation<ClientValidationInput, ClientValidationOutput>
    {
        public override void DoExecute()
        {
            ClientValidationOutput output = new ClientValidationOutput();

            DAL.Context.Client client = this.Uow.GetRepository<Evanto.DAL.Context.Client>().Get(c=>c.OAuthClientID == this.Parameters.ClientId && c.OAuthClientSecret == this.Parameters.ClientSecret);

            // Checks if the user is null or not
            if (client == null)
            {
                // Set error
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "ClientNotCorrect",
                    Text = "Client is not correct"
                });

                // Return
                return;
            }
            
            output.IsValid = true;

            Result.Output = output;
        }
    }
}
