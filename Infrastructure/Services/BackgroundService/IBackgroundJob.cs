using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Infrastructure.Services.BackgroundService
{
    public interface IBackgroundJob
    {
        public Task AddTagNewToCourse();
        public Task AddTagBestSellToCourse();
    }
}
