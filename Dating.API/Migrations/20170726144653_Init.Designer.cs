using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dating.API.Data;

namespace Dating.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170726144653_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Dating.API.Entities.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InterestTypeId");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("InterestTypeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Dating.API.Entities.InterestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InterestTypes");
                });

            modelBuilder.Entity("Dating.API.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLiked");

                    b.Property<int?>("LikedId");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("LikedId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Dating.API.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DateRead");

                    b.Property<DateTime>("MessageSent");

                    b.Property<int>("ParentId");

                    b.Property<int?>("ProfileId");

                    b.Property<bool>("Read");

                    b.Property<int>("RecipientId");

                    b.Property<int>("SenderId");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Dating.API.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<int>("ProfileId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Dating.API.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("LookingFor");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Dating.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dating.API.Entities.Value", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Dating.API.Entities.Interest", b =>
                {
                    b.HasOne("Dating.API.Entities.InterestType", "InterestType")
                        .WithMany()
                        .HasForeignKey("InterestTypeId");

                    b.HasOne("Dating.API.Entities.Profile")
                        .WithMany("Interests")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Dating.API.Entities.Like", b =>
                {
                    b.HasOne("Dating.API.Entities.User", "Liked")
                        .WithMany()
                        .HasForeignKey("LikedId");

                    b.HasOne("Dating.API.Entities.Profile")
                        .WithMany("Likes")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Dating.API.Entities.Message", b =>
                {
                    b.HasOne("Dating.API.Entities.Profile")
                        .WithMany("Messages")
                        .HasForeignKey("ProfileId");

                    b.HasOne("Dating.API.Entities.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dating.API.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dating.API.Entities.Photo", b =>
                {
                    b.HasOne("Dating.API.Entities.Profile", "Profile")
                        .WithMany("Photos")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dating.API.Entities.Profile", b =>
                {
                    b.HasOne("Dating.API.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Dating.API.Entities.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
