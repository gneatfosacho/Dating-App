using System;
using System.Collections.Generic;

namespace Dating.API.Dtos
{
    public class ProfilesToReturnDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}