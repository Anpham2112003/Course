using Application.MediaR.Comands.User;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maper
{
    public class MapData : Profile
    {
        protected MapData()
        {
            CreateMap<UpdateProfileUserRequest, UserEntity>();

        }
    }
}
