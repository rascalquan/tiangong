using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace tiangong.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            //配置swagger
            services.AddSwaggerGen(options =>
            {
                //配置swagger文档基本信息
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "天宫",
                    Version = "v1.0.0",
                    Description = "天宫接口文档",
                    Contact = new OpenApiContact() { Name = "rascal" }
                });

                //配置接口注释
                //并加入控制器注释
                options.IncludeXmlComments(
                    filePath: Path.Combine(AppContext.BaseDirectory, "tiangong.xml"),
                    includeControllerXmlComments: true
                    );

                //配置授权：
                //在header中添加token头
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //配置jwt
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "JWT授权（数据将在header中），直接在下框中输入 Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            return services;
        }
    }
}
