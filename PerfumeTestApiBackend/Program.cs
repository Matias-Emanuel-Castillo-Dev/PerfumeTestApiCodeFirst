using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.DataAccess;

namespace PerfumeTestApiBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //add DbContext
            const string CONNECTIONNAME = "PerfumeTestDb";
            var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
            builder.Services.AddDbContext<PerfumeTestDbContext>(options => options.UseSqlServer(connectionString));


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

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowLocalhost");

            app.Run();
        }
    }
}
