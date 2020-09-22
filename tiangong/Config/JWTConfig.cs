using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TianGong.Config
{
    public class JWTConfig
    {
        public const string SectionName = "JWTConfig";

        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
