namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class PollConfiguration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.HasIndex(poll => poll.Title).IsUnique();
        builder.Property(poll => poll.Title).HasMaxLength(100);
        builder.Property(poll => poll.Summary).HasMaxLength(1500);
    }
}
