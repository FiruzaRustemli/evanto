using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.File.Delete;

namespace Evanto.BL.Operations.FileOperations
{
    public class DeleteFileByIdInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType =typeof(DeleteFileResource))]
        public int Id { get; set; }
    }
    public class DeleteFileByIdOutput
    {
        public bool IsDeleted { get; set; } 
    }
}
