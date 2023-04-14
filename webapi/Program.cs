using UserManager.StartupExtension;
using webapi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureDatabase(builder.Configuration);

var app = builder.Build();
app.UseExceptionHandlerMiddleware();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
