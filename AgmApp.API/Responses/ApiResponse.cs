using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgmApp.API.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            this.Data = data;
        }
        public T Data { get; set; }
    }
}
