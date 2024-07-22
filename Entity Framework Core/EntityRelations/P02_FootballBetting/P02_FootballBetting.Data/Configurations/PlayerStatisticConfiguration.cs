using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data.Configurations;

public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
{
    public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
    {
        builder
            .HasKey(ps => new { ps.PlayerId, ps.GameId });
    }
}