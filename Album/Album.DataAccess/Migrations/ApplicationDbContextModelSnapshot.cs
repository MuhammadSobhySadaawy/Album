﻿// <auto-generated />
using System;
using Album.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Album.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Album.Models.Domain.GllaryAlbums.AlbumAttachment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<int?>("galleryAlbumId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("isEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pathUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("sortNumber")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("galleryAlbumId");

                    b.ToTable("AlbumAttachment");
                });

            modelBuilder.Entity("Album.Models.Domain.GllaryAlbums.GalleryAlbum", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("coverPhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coverPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("isEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("GalleryAlbums");
                });

            modelBuilder.Entity("Album.Models.Domain.GllaryAlbums.AlbumAttachment", b =>
                {
                    b.HasOne("Album.Models.Domain.GllaryAlbums.GalleryAlbum", "GalleryAlbum")
                        .WithMany("albumAttachments")
                        .HasForeignKey("galleryAlbumId");

                    b.Navigation("GalleryAlbum");
                });

            modelBuilder.Entity("Album.Models.Domain.GllaryAlbums.GalleryAlbum", b =>
                {
                    b.Navigation("albumAttachments");
                });
#pragma warning restore 612, 618
        }
    }
}
