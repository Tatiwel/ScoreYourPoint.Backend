using ScoreYourPoint.Services.Sports;
using ScoreYourPoint.Services.Users;
using ScoreYourPointApi.Infra.Data;

namespace ScoreYourPoint.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            AddServicesScoped(builder.Services);

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

            app.Run();
        }

        private static void AddServicesScoped(IServiceCollection services)
        {
            services.AddScoped<ISportsService, SportsService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
