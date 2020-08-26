using SmartaceEDMS.API.Application.SharedServices.DTO;
using SmartaceEDMS.API.Application.SharedServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.SharedServices.Concrete
{
    public class CommonServices : ICommonServices
    {
        public MessageOut OutputMessage(bool isSuccessful, string message) => new MessageOut { IsSuccessful = isSuccessful, Message = message };

        public bool LogError(Exception ex)
        {
            return true;
        }
    }
}
