using AutoMapper;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Unit0fWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        public UnitOfWork(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

        }

        public DbContext GetContext()
        {
            return _dbContext;
        }

        public IQueryable<T> QueryableEntity<T>() where T : class
        {
            return _dbContext.Set<T>().AsQueryable();
        }




        //////////////////////////*****************/////////////////////////

        public IAccountRepository<AccountEntity> accountRepository

            => new AccountRepository(_dbContext);

        public IUserRepository<UserEntity> userRepository

            => new UserRepository(_dbContext);

        public IRoleRepository<RoleEntity> roleRepository

            => new RoleRepository(_dbContext);

        public ICourseRepository<CourseEntity> courseRepository

            => new CourseRepository(_dbContext);

        public ICategoryLessonRepository<CategoryLessonEntity> categoryLessonRepository

            => new CategoryLessonRepository(_dbContext);

        public ITagRepository<TagEntity> tagRepository

            => new TagRepository(_dbContext);

        public IConversationRepository<ConversationEntity> conversationRepository

            => new ConversationRepository(_dbContext);

        public ITopicRepository<TopicEntity> topicRepository

            => new TopicRepository(_dbContext);

        public IFeedbackRepository<FeedbackEntity> feedbackRepository

            => new FeedbackRepository(_dbContext);

        public IPurchaseRepository<PurchaseEntity> purchaseRepository

            => new PurchaseRepository(_dbContext);

        public ILessonRepository<LessonEntity> lessonRepository

            => new LessonRepository(_dbContext);

        public ICartRepository<CartEntity> cartRepository

            => new CartRepository(_dbContext);

        public IPaymentRepository<PaymentEntity> paymentRepository
            => new PaymentRepository(_dbContext);
    }
}
