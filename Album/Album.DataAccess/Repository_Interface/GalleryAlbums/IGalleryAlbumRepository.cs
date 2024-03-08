using Album.Models.API.Request;
using Album.Models.API.Response;
using Album.Models.Domain.GllaryAlbums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.DataAccess.Repository_Interface.GllaryAlbums
{
    public interface IGalleryAlbumRepository
    {
        Task<GalleryAlbum> GetById(int id);
        Task<IEnumerable<GalleryAlbum>> GetAll();
        Task<int?> Save(AlbumRequest albumRequest);
        Task<int?> Delete(int id);
    }
}
