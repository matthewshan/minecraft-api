
using matthewshan.MinecraftUtils.Api.Rcon.Configuration;
using matthewshan.MinecraftUtils.Api.Rcon.DataAccess;
using matthewshan.MinecraftUtils.Api.Rcon.Interfaces;
using matthewshan.MinecraftUtils.Api.Rcon.Services;

namespace matthewshan.MinecraftUtils.Api.Rcon;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ASP.NET Core Configuration
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configuration
        builder.Services.AddOptions<RconSettings>()
            .Bind(builder.Configuration.GetSection(nameof(RconSettings)))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Data Access
        builder.Services.AddHttpClient(nameof(MojangApiClient));
        builder.Services.AddScoped<IRconClient, RconClient>();
        builder.Services.AddSingleton<IMojangApiClient, MojangApiClient>();

        // Services
        builder.Services.AddScoped<IMinecraftService, MinecraftService>();
        builder.Services.AddMemoryCache();

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
}
