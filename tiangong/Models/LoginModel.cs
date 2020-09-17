using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace tiangong.Models
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string password { get; set; }
    }
}
