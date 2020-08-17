using CommonLayer.RequestModels;
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
    public class DataOperationRL : IDataOperationRL
    {
        public IConfiguration Configuration { get; }

        public DataOperationRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public List<SearchRecordResponse> SearchRecord(string name, string type,double rating, string description)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.Configuration["Data:ConnectionString"]);
                SqlCommand sqlCommand = new SqlCommand("spSearchRecord", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@type", type);
                sqlCommand.Parameters.AddWithValue("@rating", rating);
                sqlCommand.Parameters.AddWithValue("@description", description);
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                List<SearchRecordResponse> searchRecord = new List<SearchRecordResponse>();
                while (dataReader.Read())
                {
                    SearchRecordResponse Record = new SearchRecordResponse()
                    {
                        ProductName = dataReader["name"].ToString(),
                        Image = dataReader["imagee"].ToString(),
                        Price = dataReader["price"].ToString(),
                        Rating = Convert.ToDouble(dataReader["rating"]),
                        User = Convert.ToInt32(dataReader["users"]),
                        Type = dataReader["type"].ToString(),
                        Description = dataReader["description"].ToString(),
                    };
                    searchRecord.Add(Record);

                }
                sqlConnection.Close();
                return searchRecord;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SearchRecordResponse> FilterRecord(double MinimumPrice, double MaximumPrice, double MinimumRating, double MaximumRating)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.Configuration["Data:ConnectionString"]);
                SqlCommand sqlCommand = new SqlCommand("spFilterRecord", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MinimumPrice", MinimumPrice);
                sqlCommand.Parameters.AddWithValue("@MaxPrice", MaximumPrice);
                sqlCommand.Parameters.AddWithValue("@MinRating", MinimumRating);
                sqlCommand.Parameters.AddWithValue("@MaxRating", MaximumRating);
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                List<SearchRecordResponse> filterRecord = new List<SearchRecordResponse>();
                while (dataReader.Read())
                {
                    SearchRecordResponse Record = new SearchRecordResponse()
                    {
                        ProductName = dataReader["name"].ToString(),
                        Image = dataReader["imagee"].ToString(),
                        Price = dataReader["price"].ToString(),
                        Rating = Convert.ToDouble(dataReader["rating"]),
                        User = Convert.ToInt32(dataReader["users"]),
                        Type = dataReader["type"].ToString(),
                        Description = dataReader["description"].ToString(),
                    };
                    filterRecord.Add(Record);

                }
                sqlConnection.Close();
                return filterRecord;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
