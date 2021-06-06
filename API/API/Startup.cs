
using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(o => o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "MyApi",
                Version = "v1",
                Description = "Des1"
            }));
            services.AddDbContext<dp_musicContext>(
            options => options.UseMySQL(Configuration.GetConnectionString("Dp_Database")));
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins(Configuration.GetSection("UIHosts:WebSpeakHost").Value)
            .AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
            services.AddScoped<dp_musicContext>();
            services.AddControllers();
            services.AddTransient<IGenreService, GenreServices>();
            services.AddTransient<IAccountService, RegistrationService>();
            services.AddTransient<ILogInService, LogInService>();
            services.AddTransient<ILogOutService, LogOutService>();
            services.AddTransient<IAuthenticatedUser, IsAuthenticatedUserService>();
            services.AddTransient<IUserValidationService, UserValidationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBandService, BandService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<ICompositionService, CompositionService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.RequireHttpsMetadata = true;
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidIssuer = Configuration["Jwt:Issuer"],
                                ValidateAudience = true,
                                ValidAudience = Configuration["Jwt:Audience"],
                                ValidateLifetime = true,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                                ValidateIssuerSigningKey = true,
                            };
                            options.Events = new JwtBearerEvents
                            {
                                OnMessageReceived = context =>
                                {
                                    context.Token = context.Request.Cookies["jwtToken"];
                                    return Task.CompletedTask;
                                }
                            };
                        });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(env.ContentRootPath, "wwwroot")),
                RequestPath = "/wwwroot"
            });

            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}