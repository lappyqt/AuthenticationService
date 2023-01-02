using AuthenticationService.API;
using AuthenticationService.BL;
using AuthenticationService.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.Load("../");

builder.Services.AddDALLayer(builder.Configuration);
builder.Services.AddBLLayer(builder.Environment);
builder.Services.AddJWT(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "API is working...");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();