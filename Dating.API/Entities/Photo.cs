using System;

namespace Dating.API.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
//
//        public Profile Profile { get; set; }
//        public int ProfileId { get; set; }
    }
}