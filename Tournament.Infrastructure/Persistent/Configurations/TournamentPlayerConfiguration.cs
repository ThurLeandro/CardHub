using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tournament.Domain.Entities;

public class TournamentPlayerConfiguration
    : IEntityTypeConfiguration<TournamentPlayer>
{
    public void Configure(EntityTypeBuilder<TournamentPlayer> builder)
    {
        builder.HasKey(tp => new { tp.TournamentId, tp.PlayerId });

        builder.Property(tp => tp.Points).IsRequired();
        builder.Property(tp => tp.Wins).IsRequired();
        builder.Property(tp => tp.Losses).IsRequired();
        builder.Property(tp => tp.Draws).IsRequired();
    }
}
