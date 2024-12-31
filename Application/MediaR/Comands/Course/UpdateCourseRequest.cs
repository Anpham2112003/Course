using Application.MediaR.Pipeline;
using Domain.Entities;
using Domain.Types.ErrorTypes.Unions.Course;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Course
{
    public class UpdateCourseRequest:IRequest<MutationPayload<UpdateCourseRequest,UpdateCourseError>>,IRequireValidation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public bool IsSale { get; set; }
        public int Sale { get; set; }
        public string? Description {  get; set; }
    }
}
