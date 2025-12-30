using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tournament.Domain.Entities;

public class TournamentPlayerConfiguration : IEntityTypeConfiguration<TournamentPlayer>
{
    public void Configure(EntityTypeBuilder<TournamentPlayer> builder)
    {
        builder.ToTable("TournamentPlayers");

        builder.HasKey(x => new { x.TournamentId, x.PlayerId });

        builder.Property(x => x.Points)
            .IsRequired();

        builder.Property(x => x.Wins)
            .IsRequired();

        builder.Property(x => x.Losses)
            .IsRequired();

        builder.Property(x => x.Draws)
            .IsRequired();
    }
}
