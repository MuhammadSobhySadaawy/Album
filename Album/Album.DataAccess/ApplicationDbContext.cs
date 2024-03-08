using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Album.Models.Domain.GllaryAlbums;

namespace Album.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GalleryAlbum>().HasQueryFilter(e => !e.isDeleted.Value && e.isEnabled.Value);
            modelBuilder.Entity<AlbumAttachment>().HasQueryFilter(e => !e.isDeleted.Value && e.isEnabled.Value);
        }
        public DbSet<GalleryAlbum> GalleryAlbums { get; set; }
        public DbSet<AlbumAttachment> AlbumAttachment { get; set; }
    }
}
