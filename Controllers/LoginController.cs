﻿using Microsoft.AspNetCore.Mvc;
using MamunTutorial.Data;
using MamunTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Scripting;
using MamunTutorial.DTOs;
using MamunTutorial.Services;

namespace MamunTutorial.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IJwtService _jwtService;

        public LoginController(ApplicationDBContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDto)
          {
            // Validate request data
            if (string.IsNullOrEmpty(loginDto.Identifier) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Email and password are required.");
            }

            // Find the user by email
            var user = await _context.UsersInfo
                .FirstOrDefaultAsync(u => u.Email == loginDto.Identifier);

            User userInfo = new User()
            {
                Email = user.Email,
                Role = user.Role,
                UserId = user.UserId
            };

            var test2 = _jwtService.CreateJwtToken(userInfo);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            else {
                var test = _jwtService.CreateJwtToken(userInfo);

                var authenticationResponse = _jwtService.CreateJwtToken(userInfo);

              

                return Ok(authenticationResponse);
            }

            
          
            
        }
    }
}
