using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ResponseModels
{
    public class AdminLoginResponse
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Token { get; set; }
    }
}
