using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class CreateUserInput
    {
        public int RoleId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public int? MaritalStatus { get; set; }
        [Required(ErrorMessage = "FirstName is needed")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string BirthdayString { get; set; }
        public DateTime BirthDay {
            get { return DateTime.ParseExact(BirthdayString, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { } }

        public DateTime RegistrationDate { get; set; }
        
        public string Phone { get; set; }
        public string Username { get; set; }
        
        public string PasswordString { get; set; }

        public int LoginCount { get; set; }

        public DateTime LastLoginDate { get; set; }

        public int FailedLoginCount { get; set; }
        
        public string Description { get; set; }
    }
}