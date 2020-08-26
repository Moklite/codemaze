using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.SharedServices.DTO
{
    public class ApiResult<T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }

    public class MessageOut
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
