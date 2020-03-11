using System;

namespace Evanto.BL.DTOs.Admin
{
    public class SmsQueueAdminDto
    {
    public int Id { get; set; }
      public int TypeId { get; set; }
      public int StatusId { get; set; }
      public string Status { get; set; }
      public  string Type { get; set; }
      public string Text { get; set; }
      public string Recipient { get; set; }
      public DateTime? SentDate { get; set; }
      public DateTime? CreatedDate { get; set; }
      public string Description { get; set; }

      public virtual SmsStatusAdminDto SmsStatus { get; set; }
      public virtual SmsTypeAdminDto SmsType { get; set; }
  }
}
