using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp7
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }
        public DbSet<DumbAsAPost> DumbAsAPosts { get; set; }
        public DbSet<TestBigInt> TestBigInts { get; set; }
        public DbSet<TestBigIntOrg> TestBigIntsOrg { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=localhost;Initial Catalog=EfCoreDocDB;Integrated Security=SSPI;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<VideoPost>("video")
                .HasValue<DumbAsAPost>("dumb");

            builder.Entity<TestBigInt>()
                .Property(x => x.TestBigIntId)
                //.HasConversion(Extensions.IntAndLongConverter());
                .HasConversion<long>();

            builder.Entity<TestBigIntOrg>()
                .Property(x => x.Id)
                .HasColumnType("bigint")
                .UseSqlServerIdentityColumn()
                //.ValueGeneratedNever() //SET IDENTITY_INSERT OFF
                //.Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore
                //.HasConversion(Extensions.IntAndLongConverter())
                .HasConversion(Extensions.IntAndLongConverter2())
                ;

            builder.Entity<TestBigIntOrg>()
                .Property(x => x.MyProperty)
                .HasColumnType("nvarchar(50)");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public string Discriminator { get; set; }
    }

    public class VideoPost : Post
    {
        public string VideoTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class DumbAsAPost : Post
    {
        public bool Stupid { get; set; }
    }

    public class TestBigInt
    {
        [Column(TypeName = "bigint")]
        public Int64 TestBigIntId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MyProperty { get; set; }
    }

    public class TestBigIntOrg
    {
        public int Id { get; set; }

        public string MyProperty { get; set; }
    }
}