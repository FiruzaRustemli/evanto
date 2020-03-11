using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.FileOperations
{
    public class CreateAvatarOperation : Operation<CreateAvatarInput, CreateAvatarOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        
        public override void DoExecute()
        {
            CreateAvatarOutput output = new CreateAvatarOutput();
            CreateFileOperation op=new CreateFileOperation();
            CreateFileInput fileParameters =Mapper.Map<CreateAvatarInput,CreateFileInput>(Parameters);
            fileParameters.TypeId = 1;

            DAL.Context.File existfile = Uow.GetRepository<DAL.Context.File>()
                .Get(x => x.ContentTypeId == 1 && x.RelationalId == Parameters.RelationalId && x.TypeId == Parameters.TypeId);

            OperationResult<CreateFileOutput> opResult = op.Execute(fileParameters);
            if (opResult.IsSuccess)
            {
                Uow.GetRepository<DAL.Context.File>().Delete(existfile);
                Uow.SaveChanges();

                ResizeImageOperation ResizeOp = new ResizeImageOperation();
                OperationResult<ResizeImageOutput> ResizeOpResult = ResizeOp.Execute(new ResizeImageInput{Container = fileParameters.Container,Width = 100,Height = 100});
                if (!ResizeOpResult.IsSuccess)
                {
                    Result.ErrorList.Add(new Error
                    {
                        Type = OperationResultCode.Exception,
                        Text = "File added but resizing is not success",
                        Code = "400"
                    });
                    return;
                }


                fileParameters.Container = ResizeOpResult.Output.Container;
                fileParameters.ParentId = opResult.Output.File.Id;
                fileParameters.TypeId = 2;
                op=new CreateFileOperation();
                OperationResult<CreateFileOutput> thumbOpResult = op.Execute(fileParameters);
                if (!thumbOpResult.IsSuccess)
                {
                    Result.ErrorList.Add(new Error
                    {
                        Type = OperationResultCode.Exception,
                        Text = "File added but Thumbnail didn't added",
                        Code = "400"
                    });
                }
            }
            Result.Output = output;
        }

       
        #endregion
    }
}
