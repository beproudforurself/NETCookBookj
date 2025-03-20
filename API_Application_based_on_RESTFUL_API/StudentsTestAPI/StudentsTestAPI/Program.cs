using Microsoft.EntityFrameworkCore;
using StudentsTestAPI.Data;
using StudentsTestAPI.Models;
namespace StudentsTestAPI
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

            // read connectstr from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<StudentContext>(option => option.UseSqlite(connectionString));


            var app = builder.Build();
            // ???????
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<StudentContext>();
                    // ensure database is created
                    context.Database.EnsureCreated();

                    // mock data
                    if (!context.Students.Any())
                    {
                        context.Students.AddRange(
                            new Student { Name = "aa", StudentNumber = "001", ClassName = "01" },
                            new Student { Name = "bb", StudentNumber = "002", ClassName = "02" },
                            new Student { Name = "cc", StudentNumber = "003", ClassName = "03" }
                        );
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "????????");
                }
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
