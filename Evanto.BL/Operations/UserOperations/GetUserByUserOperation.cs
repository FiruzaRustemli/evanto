using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using System;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserByUserOperation : Operation<GetUserByUserInput, GetUserOutputByUser>
    {
        public override void DoExecute()
        {
            GetUserOutputByUser output = new GetUserOutputByUser();
            var user = this.Uow.EvantoContext.SearchUser(Parameters.CurrentUserId,
                    null,
                    null,
                    null,
                    null,
                    null)
                .FirstOrDefault();

            var image = Uow.GetRepository<File>().Get(f => f.RelationalId == Parameters.CurrentUserId && f.ContentTypeId == 1 && f.TypeId == 1);

            var userDto = Mapper.Map<User, UserUserDto>(user);
            var userSettigs = this.Uow.GetRepository<UserSetting>().Get(s => s.UserId == this.Parameters.CurrentUserId);

            // TODO: This implementation doesn't have to be here.
            if (userSettigs == null)
            {
                userSettigs = new UserSetting
                {
                    LangId = 1,
                    Theme = "default",
                    UserId = Parameters.CurrentUserId,
                };

                this.Uow.GetRepository<UserSetting>().Add(userSettigs);
                this.Uow.SaveChanges();
            }

            // ------

            var languageId = userSettigs.LangId;
            var selectedCulture = this.Uow.GetRepository<Language>().Get(l => l.Id == languageId).ShortName;
            if (selectedCulture != null)
                selectedCulture = "az";

            if (image != null)
            {
                if (System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + image.Path))
                {
                    userDto.Image = Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + image.Path));
                }
                    
            }

            userDto.RegistrationDate = user.CreatedDate.Value;
            userDto.SelectedCulture = selectedCulture;
            userDto.SelectedTheme = userSettigs.Theme;

            output.User = userDto;
            Result.Output= output;
        }
    }
}
