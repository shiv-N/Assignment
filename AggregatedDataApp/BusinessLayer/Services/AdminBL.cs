using BusinessLayer.Interfaces;
using CommonLayer.Models;
using CommonLayer.ResponseModels;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;
        
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public AdminLoginResponse AdminLogin(AdminLoginModel loginModel)
        {
            try
            {
                return adminRL.AdminLogin(loginModel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
