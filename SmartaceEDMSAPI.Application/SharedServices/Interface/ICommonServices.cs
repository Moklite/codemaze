using Abp.Application.Services;
using SmartaceEDMS.API.Application.SharedServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application.SharedServices.Interface
{
    public interface ICommonServices : IApplicationService
    {
        MessageOut OutputMessage(bool isSuccessful, string message);

        bool LogError(Exception ex);
    }
}
