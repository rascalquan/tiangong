using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianGong.Config;

namespace TianGong.Extensions
{ 
    public static class ConfigExtensions
    {
        /// <summary>
        /// 统一的配置类配置方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomConfig(this IServiceCollection services,IConfiguration configuration)
        {
            //return services.Configure<JWTConfig>(configuration.GetSection(JWTConfig.SectionName));
            return services.AddCustomConfig<JWTConfig>(configuration);
        }

        public static IServiceCollection AddCustomConfig<T>(this IServiceCollection services,IConfiguration configuration) where T:class
        {
            return services.Configure<T>(configuration.GetSection(typeof(T).Name));
        }
    }
}
