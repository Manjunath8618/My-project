using BookStoreApp.Data;
using BookStoreApp.Model;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStoreApp
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
            
            services.AddDbContext<BooksDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("BooksDB")));

            //addedIdentity
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<BooksDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options=>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience=false,
                        ValidAudience= Configuration["JWT:ValidAudience"],
                        ValidIssuer= Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                    };
                });
            

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<IUser,User>();
            services.AddAutoMapper(typeof(Startup));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStoreApp", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseSwagger();
               // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStoreApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

             app.UseAuthentication();
             app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
