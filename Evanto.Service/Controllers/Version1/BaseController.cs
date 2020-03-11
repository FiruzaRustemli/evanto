using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Evanto.BL;
using Evanto.Service.Helpers;
using Microsoft.AspNet.SignalR;
using Evanto.Service.Hubs;

namespace Evanto.Service.Controllers.Version1
{
    /// <summary>
    /// Manages all API.
    /// </summary>
    public class BaseController : ApiController
    {

        #region Properties

        public IHubContext hubContext;

        #endregion

        #region Constructors
        public BaseController()
        {
            hubContext = GlobalHost.ConnectionManager.GetHubContext<ServiceHub>();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Creates api result built by logic result.
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public CreateResult<TResult> Result<TResult>(OperationResult<TResult> result) where TResult : class
        {
            return new CreateResult<TResult>(result, Request);
        }

        #endregion
    }
}
