using System;
using System.Collections.Generic;
using Dating.API.Entities;

namespace Dating.API.Dtos
{
    public class ProfileToReturnForDetailDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }

        public string Description { get; set; }
        public string LookingFor { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Interest> Interests { get; set; }
    }
}