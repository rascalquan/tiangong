using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiangong.Config;

namespace tiangong.Extensions
{ 
    public static class ConfigExtensions
    {
        public static IServiceCollection AddCustomConfig(this IServiceCollection services,IConfiguration configuration)
        {
            return services.Configure<JWTConfig>(configuration.GetSection(JWTConfig.SectionName));
        }
    }
}
