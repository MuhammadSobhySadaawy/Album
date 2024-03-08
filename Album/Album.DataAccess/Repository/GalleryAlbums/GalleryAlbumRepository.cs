using Album.DataAccess.Repository_Interface.GllaryAlbums;
using Album.Models.API.Request;
using Album.Models.API.Response;
using Album.Models.Domain.GllaryAlbums;
using Album.DataAccess.Repository.DefualtRepository;
using Album.Infrastructure.StaticData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Album.Infrastructure.Helpers.IHelper.FileUpload;
using Microsoft.AspNetCore.Http;
using Album.Infrastructure.Helpers;

namespace Album.DataAccess.Repository.GllaryAlbums
{
    public class GalleryAlbumRepository : Repository<GalleryAlbum>, IGalleryAlbumRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileUploadHelper _fileUploadHelper;

        public GalleryAlbumRepository(ApplicationDbContext db, IFileUploadHelper fileUploadHelper) : base(db)
        {
            _db = db;
            _fileUploadHelper = fileUploadHelper;
        }

        public async Task<int?> Delete(int id)
        {
            try
            {
                var result = await _db.GalleryAlbums
                    .IgnoreQueryFilters()
                    .Include(e => e.albumAttachments)
                    .FirstOrDefaultAsync(e => e.id == id);
                if (result is null) { return null; }
                result.isDeleted = true;
                result.modifiedAt = DateTime.UtcNow;
                if (result.albumAttachments is { Count: > 0 })
                {
                    result.albumAttachments.ForEach(z =>
                    {
                        z.isDeleted = true;
                        z.modifiedAt = DateTime.UtcNow;
                    });
                }
                await _db.SaveChangesAsync();
                return result.id;
            }
            catch { return null; }
        }

        public async Task<IEnumerable<GalleryAlbum>> GetAll()
        {
            try
            {
                return await _db.GalleryAlbums
                    .AsNoTracking()
                    .Include(e => e.albumAttachments)
                    .OrderByDescending(e => e.id)
                    .ToListAsync();
            }
            catch { return new List<GalleryAlbum>(); }
        }

        public async Task<GalleryAlbum> GetById(int id)
        {
            try
            {
                return await _db.GalleryAlbums
                    .IgnoreQueryFilters()
                    .AsNoTracking()
                    .Include(e => e.albumAttachments.OrderBy(e => e.sortNumber))
                    .FirstOrDefaultAsync(e => e.id == id);
            }
            catch { return new GalleryAlbum(); }
        }

        public async Task<int?> Save(AlbumRequest request)
        {
            try
            {
                return request.id switch
                {
                    <= 0 => await Add(request),
                    > 0 => await Edit(request)
                };
            }
            catch { return null; }
        }



        #region private
        private async Task<int?> Add(AlbumRequest request)
        {
            try
            {
                var albumAttachments = new List<AlbumAttachment>();

                if (request.albumAttachments is { Count: > 0 })
                {
                    request.albumAttachments.ForEach(async x =>
                    {
                        if (x.isDeleted is false)
                        {
                            albumAttachments.Add(new AlbumAttachment
                            {
                                createdAt = DateTime.UtcNow,
                                name = x.fileName != null ? x.fileName : "",
                                pathUrl = x.fileSource != null && x.fileSource != "" ?
                                await UploadFiles(Base64ToImage(new FileDto
                                { fileName = x.fileName, fileSource = x.fileSource }),
                                    FilePathHelper.GllaryAlbumAttachment, 0) : "",
                                isDeleted = x.isDeleted,
                                isEnabled = true,
                                sortNumber = x.sortNumber
                            });
                        }
                    });
                }
                var gllaryAlbum = new GalleryAlbum
                {
                    isDeleted = false,
                    isEnabled = true,
                    createdAt = DateTime.UtcNow,
                    description = request.description,
                    coverPhotoName = request.coverPhoto.fileName != null ? request.coverPhoto.fileName : "",
                    coverPhotoPath = request.coverPhoto.fileSource != null && request.coverPhoto.fileSource != ""
                         ? await UploadFiles(Base64ToImage(new FileDto
                         { fileName = request.coverPhoto.fileName, fileSource = request.coverPhoto.fileSource }), FilePathHelper.GllaryAlbumCover, 0) : "",
                    title = request.title,
                    albumAttachments = albumAttachments
                };
                var add = await _db.GalleryAlbums.AddAsync(gllaryAlbum);
                await _db.SaveChangesAsync();
                return add.Entity.id;
            }
            catch { return null; }
        }
        private async Task<int?> Edit(AlbumRequest request)
        {
            try
            {
                var result = await _db.GalleryAlbums
                       .IgnoreQueryFilters()
                       .Include(e => e.albumAttachments)
                       .FirstOrDefaultAsync(e => e.id == request.id);
                result.title = request.title;
                result.description = request.description;
                if (request.coverPhoto is not null && request.coverPhoto.isDeleted is false)
                {
                    result.coverPhotoName = request.coverPhoto.fileName != null ? request.coverPhoto.fileName : "";
                    result.coverPhotoPath = request.coverPhoto.fileSource != null && request.coverPhoto.fileSource != ""
                                    ? await UploadFiles(Base64ToImage(new FileDto
                                    { fileName = request.coverPhoto.fileName, fileSource = request.coverPhoto.fileSource }),
                                        FilePathHelper.GllaryAlbumCover, result.id)
                                    : result.coverPhotoPath;
                }
                if (request.coverPhoto is not null && request.coverPhoto.isDeleted is true)
                {
                    result.coverPhotoName = null;
                    result.coverPhotoPath = null;
                }

                if (request.albumAttachments is { Count: > 0 })
                {
                    foreach (var y in request.albumAttachments)
                    {
                        if (y.id != 0)
                        {
                            var Attach = result.albumAttachments.FirstOrDefault(e => e.id == y.id);
                            Attach.modifiedAt = DateTime.UtcNow;
                            Attach.name = y.fileName != null ? y.fileName : "";
                            Attach.pathUrl = y.fileSource != null && y.fileSource != ""
                                ? await UploadFiles(Base64ToImage(new FileDto
                                { fileName = y.fileName, fileSource = y.fileSource }), FilePathHelper.GllaryAlbumAttachment, result.id) : Attach.pathUrl;
                            Attach.isDeleted = y.isDeleted;
                            Attach.sortNumber = y.sortNumber;
                        }
                        else if (y.id == 0)
                        {
                            if (y.isDeleted is false)
                            {
                                result.albumAttachments.Add(new AlbumAttachment()
                                {
                                    createdAt = DateTime.UtcNow,
                                    galleryAlbumId = request.id,
                                    name = y.fileName != null ? y.fileName : "",
                                    pathUrl = y.fileSource != null && y.fileSource != ""
                                    ? await UploadFiles(Base64ToImage(new FileDto
                                    { fileName = y.fileName, fileSource = y.fileSource }),
                                        FilePathHelper.GllaryAlbumAttachment, request.id)
                                    : "",
                                    isDeleted = false,
                                    isEnabled = true,
                                    sortNumber = y.sortNumber
                                });
                            }
                        }
                    }
                }
                await _db.SaveChangesAsync();
                return result.id;
            }
            catch { return null; }
        }
        #endregion





        #region file uploaders helpers 
        private async Task<string> UploadFiles(IFormFile formFile, string path, int userId)
        {
            var imagePath = await _fileUploadHelper.Upload(formFile, path + userId.ToString());
            return imagePath;
        }
        private IFormFile Base64ToImage(FileDto attach)
        {
            byte[] bytes = Convert.FromBase64String(attach.fileSource.Substring(attach.fileSource.LastIndexOf(',') + 1));
            MemoryStream stream = new MemoryStream(bytes);
            IFormFile file = new FormFile(stream, 0, bytes.Length, attach.fileName, attach.fileName);
            return file;
        }
        private IFormFile Base64ToImage2(string attach, string fileName)
        {
            byte[] bytes = Convert.FromBase64String(attach.Substring(attach.LastIndexOf(',') + 1));
            MemoryStream stream = new MemoryStream(bytes);
            IFormFile file = new FormFile(stream, 0, bytes.Length, fileName, fileName);
            return file;
        }
        #endregion




    }
}
