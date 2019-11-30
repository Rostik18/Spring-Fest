using System.Collections.Generic;

namespace SF.Services.Models
{
    public class PagedResultDTO<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
