using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils.Helpers
{
    public class FileHelper
    {
        public string UploadFile(IFormFile file)
        {
            var webRoot = Path.Combine("wwwroot", "imgs");

            var guidFileName = Guid.NewGuid();
            var fileExtension = Path.GetExtension(file.FileName);

            var fileNameWithExtension = $"{guidFileName}{fileExtension}";
            var filePath = Path.Combine(webRoot, fileNameWithExtension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filePath;
        }
    }
}
