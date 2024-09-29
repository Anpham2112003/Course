using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Response
{
    public static class CreateResponse<T>
    {
        public static IResponse<T> Ok(string message = "success") => new Response<T>
        {
            IsSuccess = true,
            StatusCode = 200,
            Message = message,
            Payload = default
        };

        public static IResponse<T> Ok(T payload) => new Response<T>
        {
            IsSuccess = true,
            StatusCode = 200,
            Message = "success",
            Payload = payload,
        };

        public static IResponse<T> NotFound(string messsage = "not found") => new Response<T>
        {
            IsSuccess = false,
            StatusCode= 404,
            Message = messsage,
            Payload = default
        };

        public static IResponse<T> BadRequest(string messsage = "bad request") => new Response<T>
        {
            IsSuccess = false,
            StatusCode = 400,
            Message = messsage,
            Payload = default
        };

        public static IResponse<T> Unthorization(string message = "Unauthorization") => new Response<T>
        {
            IsSuccess = false,
            StatusCode = 403,
            Message = message,
            Payload = default
        };
       
    }
}
