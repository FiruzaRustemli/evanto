using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.FileOperations
{
    public class GetThumbnailOperation : Operation<GetThumbnailInput, GetThumbnailOutput>
    {
        public override void DoExecute()
        {
            GetThumbnailOutput output = new GetThumbnailOutput {Files = new List<FileDto>()};
            var predicate = PredicateBuilder.True<File>();
            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(p => p.Id == this.Parameters.Id);
            }
            if (this.Parameters.RelationalId != null)
            {
                predicate = predicate.And(p => p.RelationalId == this.Parameters.RelationalId);
            }
            if (this.Parameters.ContentTypeId != null)
            {
                predicate = predicate.And(p => p.ContentTypeId == this.Parameters.ContentTypeId);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Name))
            {
                predicate = predicate.And(p => p.Name == this.Parameters.Name);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Extension))
            {
                predicate = predicate.And(p => p.Extension == this.Parameters.Extension);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Path))
            {
                predicate = predicate.And(p => p.Path == this.Parameters.Path);
            }
            if (!String.IsNullOrEmpty(this.Parameters.MediaType))
            {
                predicate = predicate.And(p => p.MediaType == this.Parameters.MediaType);
            }
            if (this.Parameters.CreatedDate != DateTime.MinValue)
            {
                predicate = predicate.And(p => p.CreatedDate == this.Parameters.CreatedDate);
            }
            predicate = predicate.And(p => p.ParentId ==Parameters.ParentId&& p.TypeId == 2&& p.Status == true);

            var files = this.Uow.GetRepository<File>().GetAll(predicate).ToList();
             output.Files =  Mapper.Map<List<File>, List<FileDto>>(files);
            Result.Output = output;
        }
    }
}
