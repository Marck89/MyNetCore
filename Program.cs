using Serilog;

var builder = WebApplication.CreateBuilder(args);




Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();




// add services to DI container
{
    var services = builder.Services;
    services.AddControllers();
    services.AddSwaggerGen();

    string path = Directory.GetCurrentDirectory();

}


  builder.Host.UseSerilog((hostingContext, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
        );

var app = builder.Build();


// configure HTTP request pipeline
{
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
    });
    app.UseHttpLogging();
    
}

app.Run();