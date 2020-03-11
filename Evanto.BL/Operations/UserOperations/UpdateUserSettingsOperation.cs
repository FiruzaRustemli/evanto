using System.Globalization;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateUserSettingsOperation : Operation<UpdateUserSettingsInput, UpdateUserSettingsOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            UpdateUserSettingsOutput output = new UpdateUserSettingsOutput();

            Language language = this.Uow.GetRepository<Language>().Get(l => l.ShortName.Equals(this.Parameters.LangCode)) ??
                       this.Uow.GetRepository<Language>().Get(l => l.ShortName.Equals("az"));
            this.Parameters.LangId = language.Id;

            UserSetting userSetting =
                this.Uow.GetRepository<UserSetting>().Get(s => s.UserId == this.Parameters.CurrentUserId);

            userSetting = Mapper.Map(this.Parameters, userSetting);

            this.Uow.GetRepository<UserSetting>().Update(userSetting);
            this.Uow.SaveChanges();

            Result.Output = output;
        }
    }
}
