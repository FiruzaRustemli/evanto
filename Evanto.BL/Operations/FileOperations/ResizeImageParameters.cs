using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.File.Create;

namespace Evanto.BL.Operations.FileOperations
{
    public class ResizeImageInput : OperationParameters
    {
       
        //[Required(ErrorMessageResourceName = "ContainerIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        //[MaxLength(4000000, ErrorMessageResourceName = "ContainerLengthIsOverThan4000000", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string Container { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class ResizeImageOutput
    { 
        public string Container { get; set; }
    }
}
