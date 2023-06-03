using _2_DM2.Learning.WebAPI.Configuration;
using _3_DM2.Learning.Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(DomainToViewModel));

builder.Services.ResolveDependencies();

builder.Services.AddAuthentication();

builder.Services.ConfigureIdentity(builder.Configuration);

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
