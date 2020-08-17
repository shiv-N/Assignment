using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ResponseModels
{
    public class SearchRecordResponse
    {

        public string ProductName { get; set; }

        public string Image { get; set; }

        public string Price { get; set; }

        public double Rating { get; set; }

        public int User { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
    }
}
