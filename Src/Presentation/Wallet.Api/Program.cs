using Serilog;
using Serilog.Formatting;
using Wallet.Application;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddApplication();


    #region Serilog    
    builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration));
    #endregion

    #region AA

    builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", j =>
    {
        j.Authority = "https://localhost:5001/";
        j.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

    builder.Services.AddAuthorization(c =>
    {
        c.AddPolicy("myPolicy", c =>
        {
            c.RequireClaim("scope", "walletapi");
        });
    });
    #endregion

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

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers().RequireAuthorization("myPolicy");

    app.Run();
}

catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}

finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}