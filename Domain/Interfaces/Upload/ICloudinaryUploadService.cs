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
        public Task<ImageUploadResult> UploadImageAsync(IFile file ,CancellationToken cancellation=default);

        public  Task<DeletionResult> DeleteImageByPublicId(string publib_id);

        public  Task<RawUploadResult> ChuckUploadVideoAsync(string FileName, long Filesize, long CurrPos, IFile File, bool LastChuck = false, CancellationToken cancellation = default);
        public  Task<VideoUploadResult> UploadVideoAsync(IFile file, CancellationToken cancellation=default);
    }
}
