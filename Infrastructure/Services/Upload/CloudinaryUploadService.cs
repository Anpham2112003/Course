using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Interfaces.Upload;
using Domain.Options;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Upload
{
    public class CloudinaryUploadService:ICloudinaryUploadService
    {
       private readonly IOptionsMonitor<CloudinaryOption> _optionsMonitor;

       private Cloudinary cloudinary;

        public CloudinaryUploadService(IOptionsMonitor<CloudinaryOption> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;

            cloudinary = new Cloudinary(optionsMonitor.CurrentValue.CLOUDINARY_URL);
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file, CancellationToken cancellation = default)
        {
            try
            {
                var result = await cloudinary.UploadAsync(new ImageUploadParams
                {
                    AssetFolder = _optionsMonitor.CurrentValue.AssetImage,

                    File=new FileDescription
                    {
                        Stream=file.OpenReadStream(),
                    },

                    Signature= GenerateSgnature()
                    
                },cancellation);


                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GenerateSgnature()
        {
            return cloudinary.Api.SignParameters(new Dictionary<string, object>
            {
                {"time",DateTime.UtcNow }

            });
        }
    }
}
