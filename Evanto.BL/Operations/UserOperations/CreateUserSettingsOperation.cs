using System.Globalization;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class CreateUserSettingsOperation : Operation<CreateUserSettingsInput, CreateUserSettingsOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            CreateUserSettingsOutput output = new CreateUserSettingsOutput();

            Language language = this.Uow.GetRepository<Language>().Get(l => l.ShortName.Equals(this.Parameters.LangCode)) ??
                       this.Uow.GetRepository<Language>().Get(l => l.ShortName.Equals("az"));
            this.Parameters.LangId = language.Id;

            UserSetting userSetting = Mapper.Map<CreateUserSettingsInput, UserSetting>(this.Parameters);

            this.Uow.GetRepository<UserSetting>().Add(userSetting);
            this.Uow.SaveChanges();

            Result.Output = output;
        }
    }
}
