using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenacStore.API.DTOs;
using SenacStore.API.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SenacStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        public LoginController(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        [HttpPost]

        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _usuarioRepository.GetByLoginAsync(login.Email, login.Senha);
            if (usuario != null)
            {
                //gera o token        
                var claims = new[]
                               {
                    new Claim("IdUsuario", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome ?? ""),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var secretKey = _configuration.GetSection("Jwt")["Key"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "*",
                    audience: "*",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                //senao, retorna não autorizado (code 401)
                return Unauthorized();
            }
        }
    }
}
