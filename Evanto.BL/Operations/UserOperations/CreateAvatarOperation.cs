using System.Web;
using Evanto.BL.Operations.FileOperations;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserOperations
{
    public class CreateAvatarOperation : Operation<CreateAvatarInput, CreateAvatarOutput>
    {
        public override void DoExecute()
        {
            CreateAvatarOutput output = new CreateAvatarOutput();
            CreateFileOperation createFileOperation = new CreateFileOperation();
            CreateFileInput createFileInput = new CreateFileInput();

            createFileInput.TypeId = 1; //TODO Should be enum
            createFileInput.ContentTypeId = 1;
            createFileInput.Extension = this.Parameters.Extension;
            createFileInput.Container = this.Parameters.Container;
            createFileInput.MediaType = this.Parameters.MediaType;
            createFileInput.Path = ConfigHelper.GetAppSetting("SaveProfileImages");
            File profilePhoto = Uow.GetRepository<File>()
                .Get(p => p.ContentTypeId == 1
                && p.RelationalId == this.Parameters.CurrentUserId //userId
                && p.Status == true);
            if (profilePhoto != null)
            {
                profilePhoto.Status = false;
                Uow.GetRepository<File>().Update(profilePhoto);
                Uow.SaveChanges();
            }

            OperationResult<CreateFileOutput> opResult = createFileOperation.Execute(createFileInput);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
