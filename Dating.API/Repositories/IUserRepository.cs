using System.Collections.Generic;
using Dating.API.Dtos;
using Dating.API.Entities;

namespace Dating.API.Repositories
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetUserWithProfiles(int userId);
        User GetProfile(int id);
        Profile GetProfileByUserId(int userId);
        User Create(User user, string password);
        void UpdateProfile(Profile profile);
        void Delete(int id);
        bool UserExists(int userId);
        bool Save();
    }
}