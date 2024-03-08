using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Models.Domain.GllaryAlbums
{
    public class GalleryAlbum : Defaults
    {
        public GalleryAlbum()
        {
            albumAttachments = new List<AlbumAttachment>();
        }
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? coverPhotoPath { get; set; }
        public string? coverPhotoName { get; set; }
        public List<AlbumAttachment> albumAttachments { get; set; }
    }
}
