﻿
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    
    public class UserEntity : BaseEntity<Guid>,ISoftDeleted,IUpdated
    {
        
       
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public bool Gender {  get; set; }
        public string? Avatar { get; set; }
        
        public bool IsLecturer { get; set; }
        public string? Information {  get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }




        /////////////////////////////////////////////
        public AccountEntity? accountEntity { get; set; }
        public List<CourseEntity> courseEntities { get; set; } = new List<CourseEntity>();
        public List<PurchaseEntity> purchaseEntities { get; set; } = new List<PurchaseEntity>();
          
        public List<CartEntity> cartEntities { get; set; } =new List<CartEntity>();
        public List<CommentEntity> commentEntities { get; set; } = new List<CommentEntity>();
        public List<PaymentEntity> paymentEntities { get; set; } = new List<PaymentEntity>();
        public List<CategoryLessonEntity> categoryLessonsEntities { get; set; } = new List<CategoryLessonEntity>();
        public List<LessonEntity> lessonsEntities { get; set; } = new List<LessonEntity>();
        public List<FeedbackEntity> feedbackEntities { get; set; }=new List<FeedbackEntity>();
     
        
        
    }
}
