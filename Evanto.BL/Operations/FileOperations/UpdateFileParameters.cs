using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.File.Update;

namespace Evanto.BL.Operations.FileOperations
{
    public class UpdateFileInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "RelationalIdIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public int RelationalId { get; set; }
        [Required(ErrorMessageResourceName = "TypeIdIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public int TypeId { get; set; }
        [Required(ErrorMessageResourceName = "ContentTypeIdIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public int ContentTypeId { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        [StringLength(50, ErrorMessageResourceName = "NameLengthIsOverThan50", ErrorMessageResourceType =typeof(UpdateFileResource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "ExtensionIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        [StringLength(10, ErrorMessageResourceName = "ExtensionLengthIsOverThan10", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public string Extension { get; set; }

        [Required(ErrorMessageResourceName = "PathIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        [StringLength(500, ErrorMessageResourceName = "PathLengthIsOverThan500", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public string Path { get; set; }

        [Required(ErrorMessageResourceName = "MediaTypeIsRequired", ErrorMessageResourceType = typeof(UpdateFileResource))]
        [StringLength(100, ErrorMessageResourceName = "MediaTypeLengthIsOverThan100", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public string MediaType { get; set; }

        [StringLength(50, ErrorMessageResourceName = "DescriptionLengthIsOverThan50", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public string Description { get; set; }

        [StringLength(4000000, ErrorMessageResourceName = "ContainerLengthIsOverThan4000000", ErrorMessageResourceType = typeof(UpdateFileResource))]
        public string Container { get; set; }
    }
    public class UpdateFileOutput
    {
        public FileDto File { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
