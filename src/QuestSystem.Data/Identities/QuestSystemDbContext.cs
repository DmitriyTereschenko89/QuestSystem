using Microsoft.EntityFrameworkCore;
using QuestSystem.Data.Converters;
using QuestSystem.Data.Extentions;
using QuestSystem.Domain.Entities.Player;
using QuestSystem.Domain.Entities.Quests.Common;
using QuestSystem.Domain.Entities.Quests.Conditions;
using QuestSystem.Domain.Entities.Quests.Requirements;
using QuestSystem.Domain.Entities.Quests.Rewards;

namespace QuestSystem.Data.Identities
{
    public class QuestSystemDbContext : DbContext
    {
        public QuestSystemDbContext(DbContextOptions<QuestSystemDbContext> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestItem> QuestPlayers { get; set; }
        public virtual DbSet<Conditions> QuestConditions { get; set; }
        public virtual DbSet<Requirements> QuestRequirements { get; set; }
        public virtual DbSet<Reward> QuestReward { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Quest>(entity =>
            {
                _ = entity.HasKey(q => q.Id);
                _ = entity.Property(q => q.Name).HasMaxLength(500);
                _ = entity.Property(q => q.Description).HasMaxLength(2000);
                _ = entity.HasOne(q => q.QuestCondition)
                            .WithMany()
                            .HasForeignKey(q => q.ConditionId);
                _ = entity.HasOne(q => q.QuestRequirements)
                            .WithMany()
                            .HasForeignKey(q => q.RequirementId);
                _ = entity.HasOne(q => q.QuestReward)
                            .WithMany()
                            .HasForeignKey(q => q.RewardId);
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
                _ = entity.Property(e => e.ProgressQuestCondition).HasConversion(new ConditionsConverter());
            });

            _ = modelBuilder.Entity<Conditions>(entity =>
            {
                _ = entity.HasKey(e => e.Id);
                _ = entity.Property(e => e.ConditionDescription).HasMaxLength(100);
                _ = entity.Property(e => e.ConditionCount).IsRequired();
            });

            _ = modelBuilder.Entity<CollectSubjectCondition>().HasBaseType<Conditions>();
            _ = modelBuilder.Entity<VisitSpecificLocationCondition>().HasBaseType<Conditions>();
            _ = modelBuilder.Entity<WinMonstersCondition>().HasBaseType<Conditions>();

            _ = modelBuilder.Entity<Requirements>(entity =>
            {
                _ = entity.HasKey(e => e.Id);
                _ = entity.Property(e => e.MinimumLevel).IsRequired();
            });

            _ = modelBuilder.Entity<Reward>(entity =>
            {
                _ = entity.HasKey(e => e.Id);
            });

            _ = modelBuilder.Entity<RewardCurrency>().HasBaseType<Reward>();
            _ = modelBuilder.Entity<RewardExperience>().HasBaseType<Reward>();
            _ = modelBuilder.Entity<RewardItem>().HasBaseType<Reward>();

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
