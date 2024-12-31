using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Unit0fWork
{
    public interface IUnitOfWork : IDisposable
    {
        public DbContext GetContext();
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        public Task<int> SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public IConfigurationProvider GetMapperConfiguration();

        public IQueryable<T> QueryableEntity<T>() where T:class;


        public IAccountRepository<AccountEntity> accountRepository { get; }
        public IUserRepository<UserEntity> userRepository { get; }
        public ICourseRepository<CourseEntity> courseRepository { get; }
        public ICategoryLessonRepository<CategoryLessonEntity> categoryLessonRepository { get; }
        public ITagRepository<TagEntity> tagRepository { get; }
        public IRoleRepository<RoleEntity> roleRepository { get; }
        public ITopicRepository<TopicEntity> topicRepository { get; }
        public IFeedbackRepository<FeedbackEntity> feedbackRepository { get; }
        public IPurchaseRepository<PurchaseEntity> purchaseRepository { get; }
        public ILessonRepository<LessonEntity> lessonRepository { get; }
        public ICartRepository<CartEntity> cartRepository { get; }
        public IPaymentRepository<PaymentEntity> paymentRepository { get; }
        public ICommentRepository<CommentEntity> commentRepository { get; }
        public IPermissionRepository<PermissionEntity> permissionRepository { get; }
    }
}
