using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebRestaurantes.Domain;
using WebRestaurantes.WebAPI.Dtos;

namespace WebRestaurantes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IConfiguration config,
                              IAuthenticationService authenticationService,
                              IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _authenticationService = authenticationService;
        }

        [HttpGet("GetUser")]
        [AllowAnonymous] //TODO: remover isso futuramente
        public IActionResult GetUserById(int userId)
        {
            var user = _authenticationService.GetUserById(userId);
            var userToReturn = _mapper.Map<UserDto>(user);

            if (user == null)
            {
                return NotFound($"Usuário {userId} não encontrado");
            }

            //var responseUser = _mapper.Map<UserDto>(user);

            return Ok(userToReturn);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                var createdUser = _authenticationService.CreateUser(user);

                if (createdUser == null)
                {
                    return ValidationProblem("ocorreu algum problema ao criar o usuário");
                }

                var userToReturn = _mapper.Map<UserDto>(user);

                return Created("GetUser", userToReturn);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginDto userLogin)
        {
            try
            {
                User usr = _authenticationService.ValidateUser(userLogin.Login, userLogin.Password);                

                if (usr != null)
                {
                    var mapUserLogin = _mapper.Map<UserLoginDto>(usr);

                    return Ok(new
                    {
                        token = GenerateJWToken(usr).Result,
                        user = mapUserLogin
                    });
                }

                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        private async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

            claims.Add(new Claim(ClaimTypes.Role, user.Role.Description));

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}