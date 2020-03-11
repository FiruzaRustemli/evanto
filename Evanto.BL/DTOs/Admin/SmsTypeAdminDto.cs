using System;

namespace Evanto.BL.DTOs.Admin
{
  public class SmsTypeAdminDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Nullable<System.DateTime> CreatedDate { get; set; }
    public string Description { get; set; }
  }
}
