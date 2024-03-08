using Microsoft.AspNetCore.Http;
using Album.Infrastructure.StaticData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Album.Infrastructure.Helpers.IHelper.FileUpload;
using Microsoft.AspNetCore.Hosting;


namespace Album.Infrastructure.Helpers.Helper.FileUpload
{
    public class FileUploadHelper : IFileUploadHelper
    {
        public static IHostingEnvironment _environment;
        public FileUploadHelper(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> Upload(IFormFile objFile, string path)
        {
            try
            {
                if (objFile != null && objFile.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + path))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + path);
                    }
                    var fileName = Guid.NewGuid() + Path.GetExtension(objFile.FileName);
                    string targetPath = _environment.ContentRootPath + "\\" + path.Replace("/", "\\") + "\\" + fileName;
                    using (FileStream fileStream = File.Create(targetPath))
                    {
                        await objFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return path + "/" + fileName;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }







    }
}
