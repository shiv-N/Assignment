using CommonLayer.Models;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRL
    {
        AdminLoginResponse AdminLogin(AdminLoginModel loginModel);
    }
}
