using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AggregatedDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AggrigationController : ControllerBase
    {
        private readonly IDataOperationBL dataOperation;
        public AggrigationController(IDataOperationBL dataOperation)
        {
                this.dataOperation = dataOperation;
        }

        [HttpGet("{name}/{type}/{rating}/{description}")]
        public IActionResult SearchRecord(string name, string type, double rating, string description)
        {
            try
            {

                List<SearchRecordResponse> result = this.dataOperation.SearchRecord(name, type, rating, description);
                if (result.Count != 0)
                {
                    return this.Ok(new { success = true, Message = "Search Opeartion successful", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, Message = "Search Opeartion unsuccessful" });
                }
            }
            catch(Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }

        [HttpGet("Filter/{MinimumPrice}/{MaximumPrice}/{MinimumRating}/{MaximumRating}")]
        public IActionResult FilterRecord(double MinimumPrice,double MaximumPrice,double MinimumRating,double MaximumRating)
        {
            try
            {

                List<SearchRecordResponse> result = this.dataOperation.FilterRecord(MinimumPrice,MaximumPrice,MinimumRating,MaximumRating);
                if (result.Count != 0)
                {
                    return this.Ok(new { success = true, Message = "Filter record Opeartion successful", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, Message = "Filter record Opeartion unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }

    }
}
