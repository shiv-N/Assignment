using CommonLayer.Models;
using CommonLayer.ResponseModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AdminRL : IAdminRL
    {
        public IConfiguration Configuration { get; }

        public AdminRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        //private readonly string ConnectionString = "Data Source=DESKTOP-G47OV5I\\SQLSERVER;Initial Catalog=AggregatedDataDB;Integrated Security=True";
        
        public AdminLoginResponse AdminLogin(AdminLoginModel loginModel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.Configuration["Data:ConnectionString"]);
                SqlCommand sqlCommand = new SqlCommand("spAdminAuthorization", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", loginModel.Email);
                sqlCommand.Parameters.AddWithValue("@Password", loginModel.Password);
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                AdminLoginResponse loginResponse = new AdminLoginResponse();
                while (dataReader.Read())
                {
                    loginResponse.Id = Convert.ToInt32(dataReader["Id"]);
                    loginResponse.FirstName = dataReader["FirstName"].ToString();
                    loginResponse.LastName = dataReader["LastName"].ToString();
                    loginResponse.Email = dataReader["Email"].ToString();
                    loginResponse.PhoneNumber = dataReader["PhoneNumber"].ToString();
                   
                }
                sqlConnection.Close();
                return loginResponse;
               
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
