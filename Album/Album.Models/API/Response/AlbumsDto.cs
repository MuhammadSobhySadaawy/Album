using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Models.API.Response
{
    public class AlbumsDto
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? coverPhoto { get; set; }
        public int? numberOfPhotos { get; set; }
    }
}
