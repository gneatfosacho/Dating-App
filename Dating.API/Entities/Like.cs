using System;

namespace Dating.API.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public User Liked { get; set; }
        public DateTime DateLiked { get; set; }
    }
}