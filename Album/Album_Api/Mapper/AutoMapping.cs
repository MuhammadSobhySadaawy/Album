using Album.Infrastructure.Helpers;
using Album.Models.API.Response;
using Album.Models.Domain.GllaryAlbums;
using AutoMapper;

namespace Album_Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AlbumAttachment, AlbumAttachmentDto>()
                    .ForMember(dest => dest.filePath, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.pathUrl) ? null : HostPathBase.UrlHostPathBase + src.pathUrl))
                    .ForMember(dest => dest.fileName, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.name) ? null : src.name));

            CreateMap<GalleryAlbum, AlbumDto>()
                  .ForMember(dest => dest.coverPhotoPath, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.coverPhotoPath) ? null : HostPathBase.UrlHostPathBase + src.coverPhotoPath))
                  .ForMember(dest => dest.coverPhotoName, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.coverPhotoName) ? null : src.coverPhotoName))
                  .ForMember(dest => dest.albumAttachments, opt => opt.MapFrom(src => src.albumAttachments));

            CreateMap<GalleryAlbum, AlbumsDto>()
                  .ForMember(dest => dest.coverPhoto, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.coverPhotoPath) ? null : HostPathBase.UrlHostPathBase + src.coverPhotoPath))
                  .ForMember(dest => dest.numberOfPhotos, opt => opt.MapFrom(src => src.albumAttachments.Count()));
            CreateMap<GalleryAlbum, FileDto>()
            .ForMember(dest => dest.filePath, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.coverPhotoPath) ? null : HostPathBase.UrlHostPathBase + src.coverPhotoPath))
            .ForMember(dest => dest.fileName, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.coverPhotoName) ? null : src.coverPhotoName));

        }
    }
}
