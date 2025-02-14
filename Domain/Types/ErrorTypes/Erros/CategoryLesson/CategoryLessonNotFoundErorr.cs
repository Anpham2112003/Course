﻿using Domain.Types.ErrorTypes.Unions.CategoryLesson;
using Domain.Types.ErrorTypes.Unions.Comment;
using Domain.Types.ErrorTypes.Unions.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.CategoryLesson
{
    public class CategoryLessonNotFoundErorr : UpdateCategoryLessonError
        , DeleteCategoryLessonError,CreateLessonError,CreateCommentError
    {
        public string? code { get; set; } = nameof(CategoryLessonNotFoundErorr);
        public string? message { get; set; } = "Not found category Lesson!";
    }
}
