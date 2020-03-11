﻿using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.File.Create;

namespace Evanto.BL.Operations.FileOperations
{
    public class CreateFileInput : OperationParameters
    {
        //[Required(ErrorMessageResourceName = "TypeIdIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        public int TypeId { get; set; }
        public int? ParentId { get; set; }
        //[Required(ErrorMessageResourceName = "ContentTypeIdIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        public int? RelationalId { get; set; }
        public int ContentTypeId { get; set; }

        //[Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        //[StringLength(50, ErrorMessageResourceName = "NameLengthIsOverThan50", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string Name { get; set; }

        //[Required(ErrorMessageResourceName = "ExtensionIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        //[StringLength(10, ErrorMessageResourceName = "ExtensionLengthIsOverThan10", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string Extension { get; set; }

        //[Required(ErrorMessageResourceName = "PathIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        //[StringLength(500, ErrorMessageResourceName = "PathLengthIsOverThan500", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string Path { get; set; }

        //[Required(ErrorMessageResourceName = "MediaTypeIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        //[StringLength(100, ErrorMessageResourceName = "MediaTypeLengthIsOverThan100", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string MediaType { get; set; }

        //[StringLength(50, ErrorMessageResourceName = "DescriptionLengthIsOverThan50", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string Description { get; set; }

        //[Required(ErrorMessageResourceName = "ContainerIsRequired", ErrorMessageResourceType = typeof(CreateFileResource))]
        //[MaxLength(4000000, ErrorMessageResourceName = "ContainerLengthIsOverThan4000000", ErrorMessageResourceType = typeof(CreateFileResource))]
        public string Container { get; set; }
    }
    public class CreateFileOutput
    {
        public FileDto File { get; set; }
        public string Container { get; set; }
    }
}
