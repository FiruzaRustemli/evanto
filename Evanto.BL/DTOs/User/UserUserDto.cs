using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class UserUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public int? MaritalStatus { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string SelectedTheme { get; set; }
        public string SelectedCulture { get; set; }
        public int GenderId { get; set; }
        public bool? EmailVerified { get; set; }
        public bool? PhoneVerified { get; set; }
        public virtual GenderUserDto Gender { get; set; }
    }
}
