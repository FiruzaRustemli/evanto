using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.UserActivationOperations;
using Evanto.BL.Operations.UserEventOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.BL.Operations.UserVerificationOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("users")]
    public class UserController : BaseController
    {
        #region Common

      //  [EvantoAuthorize(Roles = "User, Vendor")]
        [Route("account/changePassword")]
        [ResponseType(typeof(ChangePasswordUserOutput))]
        [HttpPut]
        public IHttpActionResult Put(ChangePasswordUserInput input)
        {
            var op = new ChangePasswordUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [Route("account/resetPassword")]
        [ResponseType(typeof(ResetPasswordByUserOutput))]
        [HttpPost]
        public IHttpActionResult Post(ResetPasswordByUserInput input)
        {
            var op = new ResetPasswordByUserOperation();
            var opResult = op.Execute(input);
            return Result(opResult);
        }

        [Route("account/forgotPassword")]
        [ResponseType(typeof(ForgotPasswordOutput))]
        [HttpPost]
        public IHttpActionResult Post(ForgotPasswordInput input)
        {
            var op = new ForgotPasswordOperation();
            var opResult = op.Execute(input);
            return Result(opResult);
        }

        [Route("account/verify")]
        [ResponseType(typeof(VerifyUserAccountOutput))]
        [HttpPost]
        public IHttpActionResult Post(VerifyUserAccountInput input)
        {
            var op = new VerifyUserAccountOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [Route("account/verificationCode")]
        [ResponseType(typeof(SendVerificationCodeByUserOutput))]
        [HttpPost]
        public IHttpActionResult Post(SendVerificationCodeByUserInput input)
        {
            var op = new SendVerificationCodeByUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        #endregion

        #region User

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/generalInfo")]
        [ResponseType(typeof(UpdateGeneralInfoByUserUserOutput))]
        [HttpPut]
        public IHttpActionResult Put(UpdateGeneralInfoByUserUserInput input)
        {
            var op = new UpdateGeneralInfoByUserUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/additionalInfo")]
        [ResponseType(typeof(UpdateGeneralInfoByUserUserOutput))]
        [HttpPut]
        public IHttpActionResult Put(UpdateAdditionalInfoByUserUserInput input)
        {
            var op = new UpdateAdditionalInfoByUserUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

     // [EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(GetUserOutputByUser))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetUserByUserInput input)
        {
            var op = new GetUserByUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);

        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/settings")]
        [ResponseType(typeof(CreateUserSettingsOutput))]
        [HttpPost]
        public IHttpActionResult Create(CreateUserSettingsInput input)
        {
            var op = new CreateUserSettingsOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User, Vendor")]
        [Route("user/settings")]
        [ResponseType(typeof(UpdateUserSettingsOutput))]
        [HttpPut]
        public IHttpActionResult Put(UpdateUserSettingsInput input)
        {
            var op = new UpdateUserSettingsOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [Route("user")]
        [ResponseType(typeof(CreateUserOutput))]
        [HttpPost]
        public IHttpActionResult Create(CreateUserInput input)
        {
            var op = new CreateUserOperation();
            var opResult = op.Execute(input);
            return Result(opResult);
        }
        #endregion

        #region Vendor


        #endregion
    }
}
