using CommonLayer.Models;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAdminBL
    {
        AdminLoginResponse AdminLogin(AdminLoginModel loginModel);
    }
}
