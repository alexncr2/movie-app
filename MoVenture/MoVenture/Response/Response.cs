﻿
namespace Deventure.Common.Response
{
    public class Response
    {
        public Response()
        {
			StatusCode = (int)ResponseCode.NotSet;
        }

        private Response(bool success) : this()
        {
            Success = success;
        }

        internal Response(bool success, int statusCode) : this(success)
        {
			StatusCode = (int)statusCode;
        }

        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public static bool IsSuccessful(Response response)
        {
            return response != null && response.Success;
        }
    }

    public class Response<T> : Response
        where T : class
    {
        public Response()
        {
			StatusCode = (int)ResponseCode.NotSet;
        }

        internal Response(bool success, int statusCode, T data) : base(success, statusCode)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public T Data { get; set; }
    }
}