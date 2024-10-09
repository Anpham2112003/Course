using Domain.Entities;
using Domain.Interfaces.EntityBase;
using Infrastructure.DB.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB.SQLDbContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
           
        }

        public ApplicationDBContext()
        {
        }

        public DbSet<AccountEntity> Accounts {  get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CategoryLessonEntity> CategoriesLessons { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<ConversationEntity> Conversations { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<DocumentEntity> Documents {  get; set; }
        public DbSet<ExerciseEntity> Exercises { get; set; }
        public DbSet<LessonEntity> Lessons {  get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<TopicEntity> Topics { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountEntityConfig).Assembly);
        }


        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(x =>
                    (x.Entity is ICreated || x.Entity is IUpdated || x is ISoftDeleted)
                                     && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entity in entries)
            {
                if (entity.State == EntityState.Added)
                {
                    if (entity is ICreated)
                    {
                        ((ICreated)entity.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }


                if (entity.State == EntityState.Modified)
                {
                    if (entity is IUpdated)
                    {
                        ((IUpdated)entity.Entity).UpdatedAt = DateTime.UtcNow;
                    }

                    if (entity is ISoftDeleted)
                    {
                        ((ISoftDeleted)entity.Entity).IsDeleted = true;
                        ((ISoftDeleted)entity.Entity).DeletedAt = DateTime.UtcNow;
                    }
                }

            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }




        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => 
                    (x.Entity is ICreated || x.Entity is IUpdated || x is ISoftDeleted) 
                                     && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entity in entries)
            {
                if(entity.State== EntityState.Added)
                {
                    if(entity is ICreated)
                    {
                        ((ICreated) entity.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }


                if(entity.State == EntityState.Modified)
                {
                    if(entity is IUpdated)
                    {
                        ((IUpdated) entity.Entity).UpdatedAt = DateTime.UtcNow;
                    }

                    if(entity is ISoftDeleted)
                    {
                        ((ISoftDeleted)entity.Entity).IsDeleted = true;
                        ((ISoftDeleted) entity.Entity).DeletedAt = DateTime.UtcNow;
                    }
                }
                
            }

            return base.SaveChanges();
        }
    }

   
}
