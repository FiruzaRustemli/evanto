using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.User.Models
{
  public class User
  {
    [Required]
    [MinLength(3)]
    public string UserName { get; set; }
    [Required]
    [MinLength(3)]
    public string Password { get; set; }
  }
}
