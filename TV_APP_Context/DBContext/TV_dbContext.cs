﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TV_APP_Context.Models;

namespace TV_APP_Context.DBContext
{
    public partial class TV_dbContext : DbContext
    {
        public TV_dbContext()
        {
        }

        public TV_dbContext(DbContextOptions<TV_dbContext> options)
            : base(options)
        {
        }

        public  DbSet<Event> Events { get; set; } 
        public  DbSet<Video> Videos { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ORIT-14\\SQLEXPRESS; Initial Catalog=TV_db; User id=Student ORIT ; Password=DabiduN");
                    //"Data Source=DESKTOP-DDO84UQ; Initial Catalog=TV_db; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent);

                entity.Property(e => e.IdEvent).HasColumnName("ID_Event");

                entity.Property(e => e.DateEvent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Date_Event");

                entity.Property(e => e.NameEvent)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Event");

                entity.Property(e => e.PictureEvent).HasColumnName("Picture_Event");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.IdVideo);

                entity.Property(e => e.IdVideo)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Video");

                entity.Property(e => e.SourceVideo).HasColumnName("Source_Video");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
