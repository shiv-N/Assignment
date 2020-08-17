using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class DataOperationBL : IDataOperationBL
    {
        private readonly IDataOperationRL dataOperation;

        public DataOperationBL(IDataOperationRL dataOperation)
        {
            this.dataOperation = dataOperation;
        }

        public List<SearchRecordResponse> FilterRecord(double MinimumPrice, double MaximumPrice, double MinimumRating, double MaximumRating)
        {
            try
            {
                return this.dataOperation.FilterRecord(MinimumPrice,MaximumPrice,MinimumRating,MaximumRating);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SearchRecordResponse> SearchRecord(string name, string type,double rating, string description)
        {
            try
            {
                return this.dataOperation.SearchRecord(name, type, rating, description);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
