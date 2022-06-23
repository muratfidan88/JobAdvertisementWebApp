using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.Common.ResponseObjects
{
    public class Response<T> : Response, IResponse<T>
    {
        public Response(T data, ResponseType responseType):base(responseType)
        {
            Data = data;
        }
        public Response(T data, ResponseType responseType, List<CustomValidationError> errors) : base(responseType)
        {
            Data = data;
            ValidationErrors = errors;
        }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
