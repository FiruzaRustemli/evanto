using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.DAL.UnitOfWork;

namespace Evanto.BL.Helpers
{
    public class ErrorHelper
    {
        #region Properties

        private readonly EvantoContext _context;

        #endregion

        #region Constructors

        public ErrorHelper(EvantoContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public ErrorDto GetError(string operationName, string resourceKey, int languageId)
        {
            //TODO: Do error implementation here.
           var resourceResult = _context.GetResourceText(operationName, resourceKey, languageId).First();
           return Mapper.Map<ErrorResult, ErrorDto>(resourceResult);
        }

        #endregion
    }
}
