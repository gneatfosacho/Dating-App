using System;
using System.Collections.Generic;
using Dating.API.Entities;
using Newtonsoft.Json;

namespace Dating.API.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public Profile Profile { get; set; }
    }
}