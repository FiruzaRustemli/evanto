using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class SettingsUserDto
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Theme { get; set; }
    }
}
