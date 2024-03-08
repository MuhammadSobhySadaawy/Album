using Album.DataAccess;
using Album.DataAccess.Repository.GllaryAlbums;
using Album.DataAccess.Repository_Interface.GllaryAlbums;
using Album.Infrastructure.Helpers.Helper.FileUpload;
using Album.Infrastructure.Helpers.IHelper.FileUpload;
using Album.DataAccess.Repository.DefualtRepository;
using Album.DataAccess.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.DataProviders
{
    public class DefaultDataProvider : IDefaultDataProvider
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileUploadHelper _fileUploadHelper;

        public DefaultDataProvider(ApplicationDbContext db, IFileUploadHelper fileUploadHelper)
        {
            _db = db;
            _fileUploadHelper = fileUploadHelper;
            SP = new SPProvider(_db);
            gllaryAlbum = new GalleryAlbumRepository(_db, _fileUploadHelper);
        }

        public ISPProvider SP { get; private set; }

        public IGalleryAlbumRepository gllaryAlbum { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
