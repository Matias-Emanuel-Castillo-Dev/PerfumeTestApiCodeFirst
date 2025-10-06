using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;
using PerfumeTestApiBackend.Extension;
using PerfumeTestApiBackend.Repository;
using PerfumeTestApiBackend.Services;

namespace PerfumeTestApiBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // ADD MY SERVICES
            builder.Services.AddScoped<PerfumeRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<IEncriptionService, Encription>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            //add DbContext with user secrets
            const string CONNECTIONNAME = "ConnectionStrings:DefaultConnection";
            var connectionString = builder.Configuration.GetValue<string>(CONNECTIONNAME);
            builder.Services.AddDbContext<PerfumeTestDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddJwtTokenService(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5500", "https://localhost:7190")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowLocalhost");

            app.Run();
        }
    }
}
