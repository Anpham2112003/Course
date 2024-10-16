using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Upload
{
    public interface ICloudinaryUploadService : IUploadService
    {
        public Task<ImageUploadResult> UploadImageAsync(IFormFile file ,CancellationToken cancellation=default);
    }
}
