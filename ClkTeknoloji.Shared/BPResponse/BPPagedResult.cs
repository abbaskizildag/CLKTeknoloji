using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Shared.BPResponse
{
     public class BPPagedResult<T>
    {
        public int TotalCount { get; set; }

        public T Items { get; set; }
    }
}
