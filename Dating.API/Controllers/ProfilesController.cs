using System;
using System.Collections.Generic;
using AutoMapper;
using Dating.API.Dtos;
using Dating.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dating.API.Controllers
{
    [Route("api/profiles")]
    [Authorize]
    public class ProfilesController : Controller
    {
        private IUserRepository _userRepository;

        public ProfilesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public IActionResult GetProfiles()
        {
            var userId = Convert.ToInt32(this.User.Identity.Name);
            
            var profilesFromRepo = _userRepository.GetUserWithProfiles(userId);

            var profiles = Mapper.Map<IEnumerable<ProfilesToReturnDto>>(profilesFromRepo);
            
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {   
            var profileFromRepo = _userRepository.GetProfile(id); 

            var profile = Mapper.Map<ProfileToReturnForDetailDto>(profileFromRepo);

            return Ok(profile);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, [FromBody] ProfileForUpdateDto profile)
        {
            if (profile == null)
                return BadRequest();
            
            // check the user exist
            if (!_userRepository.UserExists(id))
                return NotFound();
            
            // check the user updating the profile is the current user
            if (Convert.ToInt32(this.User.Identity.Name) != id)
                return Unauthorized();
            
            // get current profile from repository
            var profileFromRepo = _userRepository.GetProfileByUserId(id);

            Mapper.Map(profile, profileFromRepo);
            
            _userRepository.UpdateProfile(profileFromRepo);

            if (!_userRepository.Save())
            {
                throw new Exception($"Updating profile for user with {id} failed on save");
            }

            return NoContent();

        }
    }
}