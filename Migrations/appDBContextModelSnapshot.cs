﻿// <auto-generated />
using CustomBlogsAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomBlogsAPI.Migrations
{
    [DbContext(typeof(appDBContext))]
    partial class appDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomBlogsAPI.Model.myBlogsEntity", b =>
                {
                    b.Property<int>("blogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("blogId"));

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("blogContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("blogId");

                    b.HasIndex("categoryId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("CustomBlogsAPI.Model.myCategoryEntity", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"));

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("blogsCategory");
                });

            modelBuilder.Entity("CustomBlogsAPI.Model.myBlogsEntity", b =>
                {
                    b.HasOne("CustomBlogsAPI.Model.myCategoryEntity", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
