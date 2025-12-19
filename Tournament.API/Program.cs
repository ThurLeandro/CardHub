using Microsoft.EntityFrameworkCore;
using Tournament.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TournamentDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
