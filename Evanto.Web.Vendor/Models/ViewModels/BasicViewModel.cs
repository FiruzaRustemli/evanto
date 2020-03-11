using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class BasicViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? MaritalStatus { get; set; }
    }
}