using _2_DM2.Learning.WebAPI.Configuration;
using _3_DM2.Learning.Application.AutoMapper;
using _5_DM2.Learning.Infra.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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
