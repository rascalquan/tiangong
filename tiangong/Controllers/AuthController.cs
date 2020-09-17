using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using tiangong.Config;
using tiangong.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tiangong.Controllers
{
    /// <summary>
    /// 授权相关接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        JWTConfig _jwtConfig;
        public AuthController(IOptions<JWTConfig> jwtconfig)
        {
            _jwtConfig = jwtconfig.Value;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="model">登录模型</param>
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        public ActionResult Token(LoginModel model)
        {
            #region 验证账号密码
            if (model == null || string.IsNullOrEmpty(model.userName) || string.IsNullOrEmpty(model.password))
            {
                return new JsonResult(new { Code = 500, message = "用户名或密码不能为空" });
            }
            if (!(model.userName == "admin" && model.password == "admin"))
            {
                return new JsonResult(new { Code = 500, message = "用户名或密码错误" });
            } 
            #endregion

            //创建claim声明数组
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,"admin"),
                new Claim(ClaimTypes.Role,"admin"),
                new Claim(JwtRegisteredClaimNames.Email,"rascalquan@163.com"),
                new Claim(JwtRegisteredClaimNames.Sub,"tiangong"),                
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecurityKey));

            var expireAt = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                 issuer: _jwtConfig.Issuer,
                 audience: _jwtConfig.Audience,
                 claims: claims,
                 expires: expireAt,
                 signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                 );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { Code = 200, data = new { token = jwtToken, expires = expireAt } });

        }

    }
}
