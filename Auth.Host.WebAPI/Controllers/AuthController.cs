using Auth.Application.Exceptions;
using Auth.Application.Interfaces;
using Auth.Application.Models;
using Auth.Host.WebAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Auth.Host.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [Route("login")]
        public async Task<IActionResult> Post([FromBody]UserCredentialsViewModel userCredentialsViewModel)
        {
            try
            {
                var userCredentials = _mapper.Map<UserCredentials>(userCredentialsViewModel);
                var accessToken = await _authService.CreateAccessTokenAsync(userCredentials);

                return Ok(new
                {
                    auth_token = accessToken.Value,
                    expires_in = accessToken.ExpiresIn
                });
            }
            catch (InvalidUserCredentialsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidLoginOrPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}