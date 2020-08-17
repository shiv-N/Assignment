using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class FilterRecord
    {
        public int MinimumPrice { get; set; }

        [Required]
        public int MaximumPrice { get; set; }

        public int MinimumRating { get; set; }

        [Required]
        public int MaximumRating { get; set; }
    }
}
