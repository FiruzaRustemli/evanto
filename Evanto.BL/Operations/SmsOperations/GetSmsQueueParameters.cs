using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.SmsOperations
{
    public class GetSmsQueueInput : OperationParameters
    {
    public int? Id { get; set; }
      public int? TypeId { get; set; }
      public int? StatusId { get; set; }
      public string Text { get; set; }
      public string Recipient { get; set; }
      public DateTime? SentDate { get; set; }
      public DateTime? CreatedDate { get; set; }
      public string Description { get; set; }
  }
    public class GetSmsQueueOutput
    {
        public List<SmsQueueAdminDto> SmsQueues { get; set; }
    }
}
