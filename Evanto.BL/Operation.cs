using Evanto.BL;
using Evanto.DAL.Repository;
using Evanto.DAL.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using AutoMapper;
using Evanto.BL.Mapping;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL
{
  public abstract class Operation<TParameters, TResult> where TParameters : OperationParameters where TResult : class
  {
    public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private IMapper _mapper;

    #region Parameters
    public TParameters Parameters { get; set; }
    public OperationResult<TResult> Result { get; set; }
    public string Caller { get; set; }
    public UnitOfWork Uow { get; set; }

    public IMapper Mapper => _mapper ?? (_mapper = AutoMapperConfig.CreateMapper());

    #endregion
    #region Constructor
    public Operation()
    {
      Result = new OperationResult<TResult>();
      Uow = new UnitOfWork();
    }

    #endregion
    #region Custom Methods
    public OperationResult<TResult> Execute(TParameters parameters)
    {
      var json = new JavaScriptSerializer().Serialize(parameters);
      Logger.Info("Executing process started with this parameters: " +
          json.ToString() + " - Executed from this class : " +
          this.GetType().ToString());
      this.Parameters = parameters;

      // Check if the result is success
      if (!Result.IsSuccess)
        return Result;
      try
      {
        DoExecute();
      }
      catch (Exception ex)
      {
        while (ex.InnerException != null)
          ex = ex.InnerException;
        Logger.Error("Error occured: ", ex);

        Result.ErrorList.Add(new Error()
        {
          Type = OperationResultCode.Exception,
          Code = "SystemError",
          Text = "An unhandled error occured"
        });
      }
      return Result;
    }

    //private void ValidateParameters()
    //{
    //    var context = new ValidationContext(Parameters, serviceProvider: null, items: null);
    //    var validationResults = new List<ValidationResult>();
    //    Validator.TryValidateObject(Parameters, context, validationResults, true);            
    //    foreach (var item in validationResults)
    //    {
    //        Result.ErrorList.Add(item.ErrorMessage);
    //    }
    //}
    #endregion

    #region Abstract Methods
    public abstract void DoExecute();
    #endregion
  }
}
