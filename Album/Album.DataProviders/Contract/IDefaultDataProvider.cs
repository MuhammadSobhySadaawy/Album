
using Album.DataAccess.Repository_Interface.GllaryAlbums;
using Album.DataAccess.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.DataProviders
{
    public interface IDefaultDataProvider : IDisposable
    {
        ISPProvider SP { get; }
        IGalleryAlbumRepository gllaryAlbum { get; }
        void Save();
    }
}
