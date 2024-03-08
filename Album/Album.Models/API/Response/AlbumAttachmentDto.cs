namespace Album.Models.API.Response
{
    public class AlbumAttachmentDto
    {
        public int id { get; set; }
        public int? galleryAlbumId { get; set; }
        public string? filePath { get; set; }
        public string? fileName { get; set; }
        public int? sortNumber { get; set; } = 0;
        public string? fileSource { get; set; }
        public bool? isDeleted { get; set; }
    }

}
