using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentWebAPI.Models;
using StudentWebAPI.UserService;

namespace StudentWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public static UserModel UserModel = new UserModel();
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpGet, Authorize(Roles = "Admin")]
    public ActionResult<string> GetMe()
    {
        var userName = _userService.GetMyName();
        return Ok(userName);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserModel>> Register(UserLogin request)
    {
        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        UserModel.Username = request.Username;
        UserModel.PasswordHash = passwordHash;
        UserModel.PasswordSalt = passwordSalt;

        return Ok(UserModel);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserLogin request)
    {
        if (UserModel.Username != request.Username)
        {
            return BadRequest("UserModel not found.");
        }

        if (!VerifyPasswordHash(request.Password, UserModel.PasswordHash, UserModel.PasswordSalt))
        {
            return BadRequest("Wrong password.");
        }

        string token = CreateToken(UserModel);

        return Ok(token);
    }

    private string CreateToken(UserModel userModel)
    {
        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.Name, userModel.Username),
            new(ClaimTypes.Role, "Admin"),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}