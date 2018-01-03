using System.Collections.Generic;

namespace ContactApi.Models
{
    public class PagingResult<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }

        public static PagingResult<T> Create(IEnumerable<T> data, int total)
        {
            var result = new PagingResult<T>
            {
                Data = data,
                Total = total
            };

            return result;
        }
    }
}