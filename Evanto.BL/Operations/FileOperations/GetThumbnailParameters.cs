using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.FileOperations
{
    public class GetFileInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? TypeId { get; set; }
        public int? ContentTypeId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string MediaType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetFileOutput
    {
        public List<FileDto> Files { get; set; }
    }
}
