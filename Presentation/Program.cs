using Application;
using Infrastructure;
using Presentation;
using Serilog;

try
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateBootstrapLogger();

    var builder = WebApplication.CreateBuilder(args);

    Log.Information("Started app building");

    builder.Host.UseSerilog((_, loggerConfig) =>
    {
        var jsonConfig = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", 
                true, reloadOnChange: true)
            .Build();

        loggerConfig
            .ReadFrom.Configuration(jsonConfig);
    });

    builder.Services.AddApplication();
    builder.Services.AddPersistence(builder.Configuration);
    builder.Services.AddPresentation();


	var app = builder.Build();

    app.UseSerilogRequestLogging();

    app.UseExceptionHandler("/error");

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
catch (Exception ex)
{
    Log.Error(ex, "Crushed during the building");
}
finally
{
    Log.CloseAndFlush();
}