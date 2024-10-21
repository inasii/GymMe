using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.module
{
    public class response<T>
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public T resultData { get; set; }

        public response(bool success, string message, T data)
        {
            isSuccess = success;
            Message = message;
            this.resultData = data;
        }
    }

}