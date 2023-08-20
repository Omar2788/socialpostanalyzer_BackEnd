﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using socialpostanalyzer.DBContext;

#nullable disable

namespace socialpostanalyzer.Migrations
{
    [DbContext(typeof(SocialDbContext))]
    [Migration("20230725223154_changedatetimetostring")]
    partial class changedatetimetostring
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("socialpostanalyzer.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("postId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Page", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentsNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikesNum")
                        .HasColumnType("int");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SharesNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Reaction", b =>
                {
                    b.Property<int>("ReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReactionId"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("ReactionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReactionId");

                    b.HasIndex("PostId");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Shares", b =>
                {
                    b.Property<int>("ShareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShareId"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("ShareId");

                    b.HasIndex("PostId");

                    b.ToTable("Shares");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.UserPages", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserPagesId")
                        .HasColumnType("int");

                    b.HasKey("id", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPages");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Comment", b =>
                {
                    b.HasOne("socialpostanalyzer.Models.Post", "post")
                        .WithMany("comments")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Post", b =>
                {
                    b.HasOne("socialpostanalyzer.Models.Page", "page")
                        .WithMany("Posts")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Reaction", b =>
                {
                    b.HasOne("socialpostanalyzer.Models.Post", "post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Shares", b =>
                {
                    b.HasOne("socialpostanalyzer.Models.Post", "post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.UserPages", b =>
                {
                    b.HasOne("socialpostanalyzer.Models.User", "Users")
                        .WithMany("UserPages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("socialpostanalyzer.Models.Page", "Pages")
                        .WithMany("UserPages")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Page", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("UserPages");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.Post", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("socialpostanalyzer.Models.User", b =>
                {
                    b.Navigation("UserPages");
                });
#pragma warning restore 612, 618
        }
    }
}
