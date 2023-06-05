using Microsoft.EntityFrameworkCore;
using Villa_API.Models;

namespace Villa_API.Data
{
    public class AplicationDbContext : DbContext
    {
        public virtual DbSet<User> users { get; set; } = null;
        public virtual DbSet<Password> passwords { get; set; } = null;
        public virtual DbSet<Role> roles { get; set; } = null;
        public virtual DbSet<TypeWord> typeWords { get; set; } = null;
        public virtual DbSet<Word> words { get; set; } = null;
        public virtual DbSet<Phrase> phrases { get; set; } = null;
        public virtual DbSet<Verb> verbs { get; set; } = null;
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasAlternateKey(x => x.UserName);
                entity.HasOne(x => x.Role)
                .WithMany(x=>x.Users)
                .HasForeignKey(x=>x.IdRole)
                .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x=>x.Password)
                .WithOne(x=>x.User)
                .HasForeignKey<User>(x=>x.IdPassword)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(X => X.User)
                .WithOne(x => x.Password)
                .HasForeignKey<Password>(x => x.IdUsuario);
            });

            modelBuilder.Entity<Phrase>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(X => X.User)
                .WithMany(x => x.Phrases)
                .HasForeignKey(x => x.IdUsuario);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<TypeWord>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Verb>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User)
               .WithMany(x => x.Verbs)
               .HasForeignKey(x => x.IdUsuario);
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User)
               .WithMany(x => x.Words)
               .HasForeignKey(x => x.IdUsuario);
                entity.HasOne(x => x.TypeWord)
               .WithMany(x => x.Words)
               .HasForeignKey(x => x.IdTypeWord);
            });
        }
    }
}
