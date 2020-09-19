using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using tiangong.Config;
using tiangong.Extensions;
using tiangong.Repository;

namespace tiangong
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            ILogger logger = serviceProvider.GetRequiredService<ILogger<Startup>>();

            logger.LogInformation("Configureservices start");
            //�������ݿ�������
            services.AddDbContextPool<TGContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("TGConn")));

            services.AddCustomConfig(Configuration);

            services.AddControllersWithViews();

            //����jwt��֤
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwtConfig = Configuration.GetSection(JWTConfig.SectionName).Get<JWTConfig>();
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,//�Ƿ���֤Issuer
                    ValidateAudience = true,//�Ƿ���֤Audience
                    ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                    ClockSkew = TimeSpan.FromSeconds(30),//ʱ��ƫ��(��)
                    ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                    ValidAudience = jwtConfig.Audience,//Audience
                    ValidIssuer = jwtConfig.Issuer,//Issuer����ǩ��jwt������һ��
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecurityKey))//�õ�SecurityKey
                };
            });


            //����swagger
            services.AddSwaggerGen(options =>
            {
                //����swagger�ĵ�������Ϣ
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "�칬",
                    Version = "v1.0.0",
                    Description = "�칬�ӿ��ĵ�",
                    Contact = new OpenApiContact() { Name = "rascal" }
                });

                //���ýӿ�ע��
                //�����������ע��
                options.IncludeXmlComments(
                    filePath: Path.Combine(AppContext.BaseDirectory, "tiangong.xml"),
                    includeControllerXmlComments: true
                    );

                //������Ȩ��
                //��header�����tokenͷ
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //����jwt
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "JWT��Ȩ�����ݽ���header�У���ֱ�����¿������� Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
