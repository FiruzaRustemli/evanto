using Evanto.DAL.Context;

namespace Evanto.BL.Operations.FileOperations
{
    public class DeleteFileOperation : Operation<DeleteFileInput, DeleteFileOutput>
    {
        public override void DoExecute()
        {                
            File file = this.Uow.GetRepository<File>().GetById(this.Parameters.Id);
            if (System.IO.File.Exists(file.Path))
            {
                System.IO.File.Delete(file.Path);
            }
            DeleteFileOutput output = new DeleteFileOutput();
            this.Uow.GetRepository<File>().Delete(file);
            this.Uow.SaveChanges();
            output.IsDeleted = true;
            Result.Output = output;
           
        }
    }
}
