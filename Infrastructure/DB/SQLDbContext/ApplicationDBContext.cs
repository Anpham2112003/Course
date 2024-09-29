using Domain.Entities;
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
    }

   
}
