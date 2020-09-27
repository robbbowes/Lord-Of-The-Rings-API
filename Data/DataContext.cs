using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterId, cs.SkillId });

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Trimming the verge", Damage = 10 },
                new Skill { Id = 2, Name = "Flurry", Damage = 20 },
                new Skill { Id = 3, Name = "Blow the Horn of Gondor", Damage = 45 },
                new Skill { Id = 4, Name = "Look pained", Damage = 10 },
                new Skill { Id = 5, Name = "Be the best character", Damage = 300 }
            );

            Utility.CreatePasswordHash("Not so secret password for test data!1", out byte[] passwordhash, out byte[] passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = passwordhash, PasswordSalt = passwordSalt, Username = "Admin", UserRole = UserRole.Admin },
                new User { Id = 2, PasswordHash = passwordhash, PasswordSalt = passwordSalt, Username = "Penny" },
                new User { Id = 3, PasswordHash = passwordhash, PasswordSalt = passwordSalt, Username = "Elise" }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Frodo",
                    Class = RpgClass.Knight,
                    HitPoints = 100,
                    Strength = 10,
                    Defense = 10,
                    Intelligence = 15,
                    UserId = 2
                },
                new Character
                {
                    Id = 2,
                    Name = "Samwise",
                    Class = RpgClass.Knight,
                    HitPoints = 100,
                    Strength = 12,
                    Defense = 10,
                    Intelligence = 13,
                    UserId = 3
                },
                new Character
                {
                    Id = 3,
                    Name = "Boromir",
                    Class = RpgClass.Knight,
                    HitPoints = 200,
                    Strength = 25,
                    Defense = 20,
                    Intelligence = 10,
                    UserId = 3
                }
            );

            modelBuilder.Entity<Weapon>().HasData(
                new Weapon { Id = 1, Name = "Broadsword", Damage = 30, CharacterId = 3 },
                new Weapon { Id = 2, Name = "Gardening shears", Damage = 10, CharacterId = 2 },
                new Weapon { Id = 3, Name = "Sting", Damage = 20, CharacterId = 1 }
            );

            modelBuilder.Entity<CharacterSkill>().HasData(
                new CharacterSkill { CharacterId = 1, SkillId = 2 },
                new CharacterSkill { CharacterId = 1, SkillId = 4 },
                new CharacterSkill { CharacterId = 2, SkillId = 1 },
                new CharacterSkill { CharacterId = 2, SkillId = 2 },
                new CharacterSkill { CharacterId = 3, SkillId = 2 },
                new CharacterSkill { CharacterId = 3, SkillId = 3 },
                new CharacterSkill { CharacterId = 3, SkillId = 5 }
            );
        }
    }
}