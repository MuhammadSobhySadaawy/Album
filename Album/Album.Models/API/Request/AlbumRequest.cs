using Album.Infrastructure.Helpers;
using Album.Models.API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Models.API.Request
{
    public class AlbumRequest
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public FileDto? coverPhoto { get; set; }
        public List<AlbumAttachmentDto> albumAttachments { get; set; } = new List<AlbumAttachmentDto>();
    }


}
