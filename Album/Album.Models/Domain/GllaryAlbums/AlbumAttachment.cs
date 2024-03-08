using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Models.Domain.GllaryAlbums
{
    public class AlbumAttachment : Defaults
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? pathUrl { get; set; }
        public int? sortNumber { get; set; }
        public int? galleryAlbumId { get; set; }
        [ForeignKey(nameof(galleryAlbumId))]
        public GalleryAlbum? GalleryAlbum { get; set; }
    }
}
