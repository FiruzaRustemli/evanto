using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateByAdminUserInput : OperationParameters
    {
        public HttpPostedFileBase Avatar { get; set; }

        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be an Integer")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "RoleId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "RoleId must be an Integer")]
        //public int RoleId { get; set; }

        //[Required(ErrorMessage = "TypeId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "TypeId must be an Integer")]
        //public int TypeId { get; set; }

        [Required(ErrorMessage = "GenderId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "GenderId must be an Integer")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "StatusId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "StatusId must be an Integer")]
        public int StatusId { get; set; }

        //[Range(0, int.MaxValue, ErrorMessageResourceName = "UserMaritalStatusIdInvalid")]
        //public int? MaritalStatus { get; set; }

        [Required(ErrorMessage = "FirstName Is required")]
        [MaxLength(50,ErrorMessage = "FirstName must be less than 50 character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is required")]
        [MaxLength(50, ErrorMessage = "LastName must be less than 50 character")]
        public string LastName { get; set; }

        public string Container { get; set; }

        public string FileExtension { get; set; }

        public string MediaType { get; set; }

        public DateTime? Birthday { get; set; }
        
        [MaxLength(20, ErrorMessage = "Phone must be less than 20 character")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Username Is required")]
        [MaxLength(30, ErrorMessage = "Username must be less than 30 character")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Vendorname Is required")]
        //[MaxLength(100, ErrorMessage = "Vendorname must be less than 100 character")]
        public string VendorName { get; set; }

        [MaxLength(100, ErrorMessage = "Description must be less than 100 character")]
        public string Description { get; set; }

    }
    public class UpdateByAdminUserOutput
    {
        public UserAdminDto User { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
