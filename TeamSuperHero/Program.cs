using Microsoft.EntityFrameworkCore;
using TeamSuperHero.Models.Data;
using TeamSuperHero.Services.Implimentations;
using TeamSuperHero.Services.Interfaces;
using TeamSuperHero.Token;
using TeamSuperHero.Token.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IComicServices, ComicServices>();
builder.Services.AddScoped<ITeamServices, TeamServices>();
builder.Services.AddScoped<ISuperHeroServices, SuperHeroServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserToken, UserToken>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllers();

app.Run();

