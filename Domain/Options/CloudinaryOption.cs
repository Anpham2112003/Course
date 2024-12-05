using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class CloudinaryOption
    {
        public const string Cloudinary = "Cloudinary";
        public string? CLOUDINARY_URL {  get; set; }
        public string? AssetImage {  get; set; }
        public string? AssetVideo {  get; set; }
        public string? AssetFile {  get; set; }

    }
}
