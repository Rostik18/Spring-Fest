using System.Collections.Generic;

namespace SF.WebAPI.Models
{
    public class PagedResultViewModel<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
