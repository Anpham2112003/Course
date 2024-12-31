using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public class TagData
    {
        public static readonly List<TagEntity> tags = new List<TagEntity>
        {
            new TagEntity
            {
                Name="New"
            },

            new TagEntity
            {
                Name="BestSalle"
            },

            new TagEntity
            {
                Name="Top"
            }
        };
    }
}
