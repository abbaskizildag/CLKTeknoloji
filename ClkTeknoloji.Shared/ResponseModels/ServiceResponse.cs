using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Shared.ResponseModels
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
    }
}
