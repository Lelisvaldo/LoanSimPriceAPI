﻿using LoanSimPriceAPI.Dtos;
using LoanSimPriceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanSimPriceAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Username and password are required.");

        if (request.Username != "admin" || request.Password != "password")
            return Unauthorized("Invalid username or password");

        var token = authService.GenerateJwtToken(request.Username);
        return Ok(new { Token = token });
    }
}