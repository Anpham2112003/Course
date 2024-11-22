using Application.MediaR.Comands.FeedBack;
using AutoMapper;
using Domain.Entities;
using Domain.Untils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maper
{
    public class CreateFeedbackAfterMap : IMappingAction<CreateFeedbackRequest, FeedbackEntity>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateFeedbackAfterMap(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Process(CreateFeedbackRequest source, FeedbackEntity destination, ResolutionContext context)
        {
            var userId = _contextAccessor.GetId();

            if (userId.Equals(Guid.Empty))
            {
                throw new ArgumentException("Cant find UserId in HttpContext");
            }

            destination.UserId = userId;
        }
    }
}
