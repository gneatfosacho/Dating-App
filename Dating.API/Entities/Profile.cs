using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;

namespace Dating.API.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LookingFor { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Interest> Interests { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Message> Messages { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}