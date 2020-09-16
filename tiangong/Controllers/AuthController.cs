using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tiangong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("token")]
        public ActionResult Token()
        {
            //创建claim声明数组
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,"rascal"),
                new Claim(JwtRegisteredClaimNames.Email,"rascalquan@163.com"),
                new Claim(JwtRegisteredClaimNames.Sub,"tiangong")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloworldtiangong"));

            var expireAt = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                 issuer: "tiangong",
                 audience: "tiangong",
                 claims: claims,
                 expires: expireAt,
                 signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                 );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { Code = 200, data = new { token = jwtToken, expires = expireAt } });

        }

    }
}
