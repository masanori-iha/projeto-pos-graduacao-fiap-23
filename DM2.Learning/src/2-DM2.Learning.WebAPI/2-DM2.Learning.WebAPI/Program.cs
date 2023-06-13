using _2_DM2.Learning.WebAPI.Configuration;
using _3_DM2.Learning.Application.AutoMapper;
using _5_DM2.Learning.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(DomainToViewModel));

builder.Services.AddDbContext<DM2Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DM2Connection"));
});


builder.Services.ResolveDependencies();

builder.Services.AddAuthentication();

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

app.MapControllers();

app.Run();
