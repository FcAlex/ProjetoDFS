using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Extensions;
using Server.Resources;
using Server.Utilities;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> VerifyLogin([FromBody] AuthUserResource resource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var result = await _userService.FirstOrDefaultAsync(resource.Email, resource.Password);
                var user = _mapper.Map<User, UserResource>(result);

                if (result == null)
                    return BadRequest("Erro ao tentar realizar login");

                var token = CrytoFunctions.GenerateToken(_configuration);

                return Ok(new
                {
                    error = false,
                    result = new
                    {
                        token,
                        user = new { user.Id, user.Email, user.Name }
                    }
                });
            } catch
            {
                var message = "Erro ao tentar realizar o login";
                return BadRequest(new { error = true, result = new { message } });
            }
        }
    }
}
