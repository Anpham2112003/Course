﻿using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryLessonEntity : BaseEntity<Guid>, ICreated, IUpdated,ISoftDeleted
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        ////////////////////////////////////////

        public UserEntity? userEntity {  get; set; } 
        public CourseEntity? courseEntity { get; set; }
        public List<LessonEntity>? lessonEntities { get; set; }
      
    }
}
