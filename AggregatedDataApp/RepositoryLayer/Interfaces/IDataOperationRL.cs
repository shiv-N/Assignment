using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IDataOperationRL
    {
        List<SearchRecordResponse> SearchRecord(string name, string type,double rating, string description);

        List<SearchRecordResponse> FilterRecord(double MinimumPrice, double MaximumPrice, double MinimumRating, double MaximumRating);
    }
}
