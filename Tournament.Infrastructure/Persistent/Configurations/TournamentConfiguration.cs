using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tournament.Domain.Entities;

public class TournamentConfConfiguration : IEntityTypeConfiguration<TournamentConf>
{
    public void Configure(EntityTypeBuilder<TournamentConf> builder)
    {
        builder.ToTable("Tournaments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Game)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>() // IMPORTANTÍSSIMO
            .IsRequired();

        builder.Property(x => x.TotalRounds)
            .IsRequired();

        builder
            .HasMany(x => x.Players)
            .WithOne()
            .HasForeignKey(tp => tp.TournamentId);

        builder.Navigation(x => x.Players)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
