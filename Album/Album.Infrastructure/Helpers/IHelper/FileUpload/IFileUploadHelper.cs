using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Infrastructure.Helpers.IHelper.FileUpload
{
    public interface IFileUploadHelper
    {
        Task<string> Upload(IFormFile objFile, string path);
    }
}
