using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.File.Delete;

namespace Evanto.BL.Operations.FileOperations
{
    public class DeleteFileInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType =typeof(DeleteFileResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "TypeIdIsRequired", ErrorMessageResourceType = typeof(DeleteFileResource))]
        public int TypeId { get; set; }

        [Required(ErrorMessageResourceName = "ContentTypeIdIsRequired", ErrorMessageResourceType = typeof(DeleteFileResource))]
        public int ContentTypeId { get; set; }
    }
    public class DeleteFileOutput
    {
        public bool IsDeleted { get; set; } 
    }
}
