using ChatAPI.Data;
using ChatAPI.Handlers.Auth;
using ChatAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ChatAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatAPI", Version = "v1" });

                c.AddSecurityDefinition("Token", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Token"
                        }
                    },
                    new string[] { }
                }
                });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddDbContext<AppDBContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
