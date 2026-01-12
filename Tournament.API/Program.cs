using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tournament.Application.Tournaments.Create;
using Tournament.Infrastructure.Persistence;
using Tournament.Application.Tournaments.GetAll;
using Tournament.Application.Tournaments.GetById;
using Tournament.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
 .AddJsonOptions(options =>
  {
      options.JsonSerializerOptions.Converters.Add(
          new JsonStringEnumConverter()
      );
  });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();

builder.Services.AddScoped<CreateTournamentHandler>();
builder.Services.AddScoped<GetAllTournamentsHandler>();
builder.Services.AddScoped<GetTournamentByIdHandler>();

builder.Services.AddDbContext<TournamentDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
