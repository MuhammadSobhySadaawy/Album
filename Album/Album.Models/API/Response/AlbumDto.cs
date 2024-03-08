using Album.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Models.API.Response
{
    public class AlbumDto
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? coverPhotoPath { get; set; }
        public string? coverPhotoName { get; set; }
        public List<AlbumAttachmentDto> albumAttachments { get; set; } = new List<AlbumAttachmentDto>();
    }

}
