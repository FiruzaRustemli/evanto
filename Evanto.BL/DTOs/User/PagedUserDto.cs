using System.Collections.Generic;

namespace Evanto.BL.DTOs.User
{
    public class PagedUserDto<TDto>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IReadOnlyCollection<TDto> Data { get; set; }
    }
}
