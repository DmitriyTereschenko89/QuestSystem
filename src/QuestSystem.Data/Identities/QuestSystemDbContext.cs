using Microsoft.EntityFrameworkCore;
using QuestSystem.Domain.Entities.Player;
using QuestSystem.Domain.Entities.Quests;

namespace QuestSystem.Data.Identities
{
    public class QuestSystemDbContext(DbContextOptions<QuestSystemDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestItem> QuestPlayers { get; set; }
        public virtual DbSet<QuestConditions> QuestConditions { get; set; }
        public virtual DbSet<QuestRequirements> QuestRequirements { get; set; }
        public virtual DbSet<QuestReward> QuestReward { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Quest>(entity =>
            {
                _ = entity.HasKey(q => q.Id);
                _ = entity.Property(q => q.Name).HasMaxLength(500);
                _ = entity.Property(q => q.Description).HasMaxLength(2000);
                _ = entity.HasOne(q => q.QuestCondition);
                _ = entity.HasOne(q => q.QuestRequirements);
                _ = entity.HasOne(q => q.QuestReward);
            });

            _ = modelBuilder.Entity<Player>(entity =>
            {
                _ = entity.HasKey(pl => pl.Id);
                _ = entity.Property(pl => pl.Name).HasMaxLength(100);
                _ = entity.Property(pl => pl.Level).IsRequired();
            });


            _ = modelBuilder.Entity<QuestItem>(entity =>
            {
                _ = entity.HasKey(e => e.QuestPlayerId);
                _ = entity.HasOne(e => e.Player)
                      .WithMany(p => p.Quests)
                      .HasForeignKey(e => e.PlayerId);

                _ = entity.HasOne(e => e.Quest)
                      .WithMany()
                      .HasForeignKey(e => e.QuestId);

                _ = entity.Property(e => e.QuestStatus).IsRequired();
                _ = entity.Property(e => e.ProgressQuestCondition).HasMaxLength(500);
            });

            _ = modelBuilder.Entity<QuestConditions>(entity =>
            {
                _ = entity.HasKey(e => e.Id);
                _ = entity.Property(e => e.ConditionName).HasMaxLength(100);
                _ = entity.Property(e => e.ConditionCount).IsRequired();
            });

            _ = modelBuilder.Entity<QuestRequirements>(entity =>
            {
                _ = entity.HasKey(e => e.Id);
                _ = entity.Property(e => e.MinimumLevel).IsRequired();
            });

            _ = modelBuilder.Entity<QuestReward>(entity =>
            {
                _ = entity.HasKey(e => e.Id);
            });

            _ = modelBuilder.Entity<Currency>().HasBaseType<QuestReward>();
            _ = modelBuilder.Entity<Experience>().HasBaseType<QuestReward>();
            _ = modelBuilder.Entity<Item>().HasBaseType<QuestReward>();

            _ = modelBuilder.Entity<CollectSubjectCondition>().HasBaseType<QuestConditions>();
            _ = modelBuilder.Entity<VisitSpecificLocationCondition>().HasBaseType<QuestConditions>();
            _ = modelBuilder.Entity<WinMonstersCondition>().HasBaseType<QuestConditions>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
