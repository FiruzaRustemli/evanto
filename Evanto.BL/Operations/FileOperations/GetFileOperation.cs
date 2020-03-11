using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.FileOperations
{
    public class GetFileOperation : Operation<GetFileInput, GetFileOutput>
    {
        public override void DoExecute()
        {
            GetFileOutput output = new GetFileOutput();
            output.Files = new List<FileDto>();
            var predicate = PredicateBuilder.True<File>();
            if(this.Parameters.Id != null)
            {
                predicate = predicate.And(p => p.Id == this.Parameters.Id);
            }

            predicate = predicate.And(p => p.RelationalId == this.Parameters.CurrentUserId);

            if (this.Parameters.TypeId != null)
            {
                predicate = predicate.And(p => p.TypeId == this.Parameters.TypeId);
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
            var files = this.Uow.GetRepository<File>().GetAll(predicate).ToList();
             output.Files =  Mapper.Map<List<File>, List<FileDto>>(files);
            Result.Output = output;
        }
    }
}
