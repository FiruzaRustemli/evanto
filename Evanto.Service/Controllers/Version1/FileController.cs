using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.FileOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("files")]
    public class FileController : BaseController
    {
        #region Common

        [EvantoAuthorize]
        [Route("")]
        [ResponseType(typeof(GetFileOutput))] //TODO: Talk about file server.
        [HttpGet]
        public IHttpActionResult Get(GetFileInput input)
        {
            var op = new GetFileOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize]
        [Route("avatar")]
        [ResponseType(typeof(CreateImageOutput))]
        [HttpPost]
        public IHttpActionResult UploadAvatar(CreateImageInput input)
        {
            var op = new CreateImageOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize]
        [Route("delete")]
        [ResponseType(typeof(DeleteFileByIdOutput))]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]DeleteFileByIdInput input)
        {
            var op = new DeleteFileByIdOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        #endregion

        #region User

        #endregion

        #region Vendor
        [EvantoAuthorize]
        [Route("images/vendorService")]
        [ResponseType(typeof(InsertBulkImagesByVendorOutput))]
        [HttpPost]
        public IHttpActionResult InsertBulkImagesByVendor (InsertBulkImagesByVendorInput input)
        {
            var op = new InsertBulkImagesByVendorOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }
        #endregion
    }
}
