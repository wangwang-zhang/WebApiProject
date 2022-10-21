using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentWebAPI.Models;
using StudentWebAPI.Services;

namespace StudentWebAPI.Filters;

public class AuthorizationFilter : IAuthorizationFilter
{
    private StudentService _studentService;
    private ILogger _logger;

    public AuthorizationFilter(ILogger logger, StudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string tokenString = context.HttpContext.Request.Headers.Authorization.ToString();
        if (!IsReadableToken(ref tokenString))
            return;
        JwtSecurityToken jwtSecurityToken = GetJwtSecurityToken(tokenString);
        IEnumerable<Claim> claims = jwtSecurityToken.Claims;
        List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>() { new(claims) };
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentities);
        foreach (ClaimsIdentity claimsPrincipalIdentity in claimsPrincipal.Identities)
        { 
            Claim? userRole = claimsPrincipalIdentity.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);
            Claim? userName = claimsPrincipalIdentity.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
            _studentService.AddStudent(new Student("100", userName.Value, "13567849984", 15));
            _logger.LogInformation("PrincipleUsage:" + userRole.Value + "\n");
        }
    }

    private JwtSecurityToken GetJwtSecurityToken(string tokenStr)
    {
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(tokenStr);
        return jwt;
    }

    private bool IsReadableToken(ref string tokenString)
    {
        if (string.IsNullOrWhiteSpace(tokenString) || tokenString.Length < 7)
            return false;
        if (!tokenString.Substring(0, 6)
                .Equals(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme))
            return false;
        tokenString = tokenString.Substring(7);
        bool isReadable = new JwtSecurityTokenHandler().CanReadToken(tokenString);
        return isReadable;
    }
}