
using Scalar.AspNetCore;

namespace LabScalar
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            ////SCALAR/////
            app.UseSwagger(c =>
            {
                // change the OpenApi document route template for support Scalar
                // And this will consistent with .NET9 default OpenApi route in future
                c.RouteTemplate = "openapi/{documentName}.json";
            });


            app.MapScalarApiReference(options =>
            {
                options
                    .WithTitle("Easyone Service API");
                //WithCdnUrl("https://cdn.jsdelivr.net/npm/@scalar/api-reference");
            });

            app.MapControllers();

            app.Run();
        }
    }
}
