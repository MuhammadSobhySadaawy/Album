using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Infrastructure.Helpers
{
    public class FileDto
    {
        public int id { get; set; }
        public int? attachmentId { get; set; }
        public string? filePath { get; set; }
        public string? fileName { get; set; }
        public string? fileSource { get; set; }
        public bool? isDeleted { get; set; }
    }
}
