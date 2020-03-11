using Evanto.DAL.Context;

namespace Evanto.BL.Operations.FileOperations
{
    public class DeleteFileByIdOperation : Operation<DeleteFileByIdInput, DeleteFileByIdOutput>
    {
        public override void DoExecute()
        {                
            File file = this.Uow.GetRepository<File>().GetById(this.Parameters.Id);
            if (System.IO.File.Exists(file.Path))
            {
                System.IO.File.Delete(file.Path);
            }
            DeleteFileByIdOutput output = new DeleteFileByIdOutput();
            this.Uow.GetRepository<File>().Delete(file);
            this.Uow.SaveChanges();
            output.IsDeleted = true;
            Result.Output = output;
           
        }
    }
}
