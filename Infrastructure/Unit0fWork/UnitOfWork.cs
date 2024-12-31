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

        public IConfigurationProvider GetMapperConfiguration()
        {
            return this._mapper.ConfigurationProvider;
        }




        //////////////////////////*****************/////////////////////////

        public IAccountRepository<AccountEntity> accountRepository

            => new AccountRepository(_dbContext,_mapper);

        public IUserRepository<UserEntity> userRepository

            => new UserRepository(_dbContext,_mapper);

        public IRoleRepository<RoleEntity> roleRepository

            => new RoleRepository(_dbContext,_mapper);

        public ICourseRepository<CourseEntity> courseRepository

            => new CourseRepository(_dbContext,_mapper);

        public ICategoryLessonRepository<CategoryLessonEntity> categoryLessonRepository

            => new CategoryLessonRepository(_dbContext,_mapper);

        public ITagRepository<TagEntity> tagRepository

            => new TagRepository(_dbContext,_mapper);

   

        public ITopicRepository<TopicEntity> topicRepository

            => new TopicRepository(_dbContext,_mapper);

        public IFeedbackRepository<FeedbackEntity> feedbackRepository

            => new FeedbackRepository(_dbContext,_mapper);

        public IPurchaseRepository<PurchaseEntity> purchaseRepository

            => new PurchaseRepository(_dbContext,_mapper);

        public ILessonRepository<LessonEntity> lessonRepository

            => new LessonRepository(_dbContext,_mapper);

        public ICartRepository<CartEntity> cartRepository

            => new CartRepository(_dbContext,_mapper);

        public IPaymentRepository<PaymentEntity> paymentRepository

            => new PaymentRepository(_dbContext,_mapper);

     

        public ICommentRepository<CommentEntity> commentRepository 
            
            => new CommentRepository(_dbContext,_mapper);

        public IPermissionRepository<PermissionEntity> permissionRepository 
            
            => new PermissionRepository(_dbContext,_mapper);
    }
}
