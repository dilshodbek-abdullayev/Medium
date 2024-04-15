
using Medium.Application;
using Medium.Infractructure;
using Microsoft.VisualBasic;

namespace Medium.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigin = "_myAllowSpecificOrigin";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddCors(options =>
            {

                options.AddPolicy(name: MyAllowSpecificOrigin, policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyOrigin()
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

            app.UseCors(MyAllowSpecificOrigin);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
