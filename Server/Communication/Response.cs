using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Communication
{
    public class Response<T> : BaseResponse where T : class
    {
        public T Resource { get; set; }


        public Response(T resource) : this(true, string.Empty, resource) { }

        public Response(string message) : this(false, message, null) { }
    }
}
