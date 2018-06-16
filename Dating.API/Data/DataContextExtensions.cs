using System;
using System.Collections.Generic;
using System.Linq;
using Dating.API.Dtos;
using Dating.API.Entities;
using Dating.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Dating.API.Data
{
    public static class DataContextExtensions
    {
        public static void SeedData(this DataContext context)
        {
            // clear the database so we always start fresh with each demo.  Not to be used for prod
            context.Database.Migrate();
            
            context.Values.RemoveRange(context.Values);
            context.SaveChanges();
            
            // init seed data
            var values = new List<Value>()
            {
                new Value()
                {
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Name = "Value10"
                },
                new Value()
                {
                    Id = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    Name = "Value11"
                }
            };
            
            context.Values.AddRange(values);
            context.SaveChanges();
        }

        public static void SeedUsers(this DataContext context, UserRepository repository)
        {   
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
            
            var userData = System.IO.File.ReadAllText("@Data/userData.json");
            List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(userData);
            foreach (var userDto in users)
            {
                // check to see if user exists and if not create the user
                if (context.Users.Any(u => u.Username == userDto.Username))
                {
                    // map the dto to the entity
                    var user = new User
                    {
                        Id = userDto.Id,
                        FirstName = userDto.FirstName,
                        DateOfBirth = userDto.DateOfBirth,
                        Gender = userDto.Gender,
                        Username = userDto.Username
                    };
                    repository.Create(user, userDto.Password);
                }

            }

        }
    }
}