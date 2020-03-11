using System;
using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Booking.Create;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.BookingOperations
{
  public class CreateBookingByAdminInput : OperationParameters
  {
    [Required(ErrorMessage = "VendorId Is required")]
    [Range(1, int.MaxValue, ErrorMessage = "VendorId Must be an Integer")]
    public int VendorId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "UserServiceId Must be an Integer")]
    public int? VendorServiceId { get; set; }

    [Required(ErrorMessage = "BookDate Is required")]
    public DateTime BookDate { get; set; }

    [Required(ErrorMessage = "BookTime Is required")]
    public string BookTime { get; set; }

    [Required(ErrorMessage = "DeadLine Is required")]
    public DateTime DeadLine { get; set; }

    public string Description { get; set; }
  }
  public class CreateBookingByAdminOutput
  {
    public int BookingId { get; set; }
    public bool IsCreated { get; set; } = false;
  }
}
