using Conscea_Api.Data;
using Conscea_Api.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Conscea_Api;
    
class Program {
        public static void Main(String[] args) {    
        var builder = WebApplication.CreateBuilder(args);

        var ConsceaAllowSpecificOrigins = "_consceaAllowSpecificOrigins";

        var ConsceaAllowAnyOrigins = "_consceaAllowAnyOrigins";

        builder.Services.AddCors(options =>
        {
            // Set up both production and development env policies now (...*)
            options.AddPolicy(name: ConsceaAllowSpecificOrigins, policy => {
                policy.WithOrigins(
                    builder.Configuration.GetValue<string[]>("AllowedOrigins") 
                            ?? (new string[1] {"http://localhost:3000"}));
                // Additional policy change, allows any origin to make 
                // state-altering http req's like POST, PUT, etc
                policy.AllowAnyHeader();
            });
            
            options.AddPolicy(name: ConsceaAllowAnyOrigins, policy=> {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        });

        builder.Services.AddDbContext<ConsceaContext>((
            opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ConsceaDB"))));

        // Add services to the container.
        
        builder.Services.AddControllers();

        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // builder.Services.AddScoped<IAccountService, AccountService>();
        

        builder.Services.AddScoped<ITrafficTestingService, TrafficTestingService>();
        
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        
        if (app.Environment.IsDevelopment())
        {
            // (...*): and then choose correct policy based on what app.Environment.IsDevelopment() returns later
            app.UseCors(ConsceaAllowAnyOrigins);

            app.UseSwagger();
            app.UseSwaggerUI();
        } else {
            app.UseCors(ConsceaAllowSpecificOrigins);
        }
    
        app.UseHttpsRedirection();
    
        app.UseAuthorization();
    
        app.MapControllers();
    
        app.Run();
    }
}
