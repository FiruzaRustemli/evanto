using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Vendor
{
    public class FileVendorDto
    {
        public int Id { get; set; }


        public int RelationalId { get; set; }


        public int TypeId { get; set; }


        public int ContentTypeId { get; set; }


        public string Name { get; set; }


        public string Extension { get; set; }


        public string Path { get; set; }


        public string MediaType { get; set; }


        public string Description { get; set; }


        public bool? Status { get; set; }


        public DateTime? CreatedDate { get; set; }


        public ContentTypeVendorDto ContentType { get; set; }


        public FileTypeVendorDto FileType { get; set; }
        public string Container { get; set; }

    }
}
