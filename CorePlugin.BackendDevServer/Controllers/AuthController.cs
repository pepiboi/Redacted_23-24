using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CorePlugin.BackendDevServer.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _conf;
    private readonly RSA _keys;

    public AuthController(IConfiguration conf, RSA keys)
    {
        _conf = conf;
        _keys = keys;
    }

    [HttpGet]
    public string GetAuthToken()
    {
        SecurityKey key = new RsaSecurityKey(_keys);
        var token = new JwtSecurityToken(
            issuer: _conf["JWT:Issuer"],
            audience: _conf["JWT:Audience"],
            claims: new List<Claim>(),
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}