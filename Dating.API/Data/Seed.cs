using System;
using System.Collections.Generic;
using System.Linq;
using Dating.API.Dtos;
using Dating.API.Entities;
using Dating.API.Repositories;
using Newtonsoft.Json;

namespace Dating.API.Data
{
    public class Seed
    {
        private DataContext _context;
        private IUserRepository _repo;

        public Seed(DataContext context, IUserRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public void SeedValues()
        {
            _context.Database.EnsureCreated();
            // clear the database so we always start fresh with each demo.  Not to be used for prod           
            _context.Values.RemoveRange(_context.Values);
            _context.SaveChanges();
            
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
                },
                new Value()
                {
                    Id = new Guid("a3749477-f823-4124-aa4a-fc9ad6e77cd6"),
                    Name = "Value12"
                }
            };
            
            _context.Values.AddRange(values);
            _context.SaveChanges();
        }
        
        public void SeedUsers()
        {           
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
            
            var userData = System.IO.File.ReadAllText("Data/userData.json");
            List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(userData);
            foreach (var userdto in users)
            {
                var user = new User();

                // map fields from dto
                user.FirstName = userdto.FirstName;
                user.Gender = userdto.Gender;
                user.DateOfBirth = userdto.DateOfBirth;
                user.Username = userdto.Username;
                // create password hash
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(userdto.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Profile = userdto.Profile;
                
                user.Profile.LastActive = DateTime.Today;
                
                // check to see if user exists and if not create the user
                if (!_context.Users.Any(u => u.Username == user.Username))
                {
                    _context.Add(user);
                }              
                // add profile and photos to the created user: 
            }

            _context.SaveChanges();

        }
        
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if(password == null) throw new ArgumentNullException(nameof(password));
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password), "Value cannot be empty");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}