using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Data.Repositories;
using Presentation.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<IBoilerplateRespository, BoilerplateRespository>();
builder.Services.AddScoped<IBoilerplateService, BoilerplateService>();

var app = builder.Build();
app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookings API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
