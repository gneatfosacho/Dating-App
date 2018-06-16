using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Dating.API.Data;
using Dating.API.Dtos;
using Dating.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            // check that user exists
            if (user == null)
                return null;
            
            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            // authentication successful
            return user;
        }

        public IEnumerable<User> GetUserWithProfiles(int userId)
        {
            return _context.Users
                .Where(u => u.Id != userId)
                .Include(x => x.Profile)
                .ThenInclude(p => p.Photos)
                .ToList();
        }

        public User GetProfile(int id)
        {
            var profile = _context.Users
                .Include(x => x.Profile)
                .ThenInclude(x => x.Photos)
                .FirstOrDefault(p => p.Id == id);

            return profile;
        }

        public Profile GetProfileByUserId(int userId)
        {
            var profile = _context.Profiles
                .Include(x => x.User)
                .Include(x => x.Photos)
                .FirstOrDefault(p => p.UserId == userId);

            return profile;
        }

        public User Create(User user, string password)
        {
            //check password is passed in
            if(string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required");
            
            if(_context.Users.Any(x => x.Username == user.Username))
                throw new ArgumentException("This username is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
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

        public void UpdateProfile(Profile profile)
        {
            // no code in this implementation
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if(password == null)
                throw new ArgumentNullException(nameof(password));
            
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only");
            if(storedHash.Length != 64) throw new ArgumentException("Invalid length of stored hash");
            if(storedSalt.Length != 128) throw new ArgumentException("Invalid length of stored salt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}