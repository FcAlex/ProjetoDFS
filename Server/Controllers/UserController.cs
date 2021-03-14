using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Resources.Saving;
using Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Extensions;

namespace Server.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetUsersAsync()
        {
            var users = await _userService.ListAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        }

        [HttpGet("{id}")]
        public async Task<UserResource> GetUserByIdAsync(int id)
        {
            var user = await _userService.FindByIdAsync(id);
            return _mapper.Map<User, UserResource>(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            Console.WriteLine(user);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<User, UserResource>(result.User));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<User, UserResource>(result.User));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(_mapper.Map<User, UserResource>(result.User));
        }
    }
}
