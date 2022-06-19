﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeniorTemplate.Data.Context;

#nullable disable

namespace SeniorTemplate.Data.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppRefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(46)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("AppRefreshTokens", (string)null);
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AppRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "64c2b083-c54b-4d9f-ba16-1294ec1ceafa",
                            Name = "user",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "fdb2e068-85b3-4108-9830-3eb52c04f702",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "permission",
                            ClaimValue = "mt",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AppUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "777fd44b-5dde-4356-928e-654ff5840563",
                            Email = "aspadmin@asp.net",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ASPADMIN@ASP.NET",
                            NormalizedUserName = "ASPADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEMhMB5TD25L/FkonrYU9upx8wfsDCWCAD97/kNIhgkPcXvOuzoCJxe5L+fbPffZpmQ==",
                            PhoneNumberConfirmed = false,
                            Registered = new DateTime(2022, 6, 19, 19, 42, 43, 802, DateTimeKind.Utc).AddTicks(6995),
                            SecurityStamp = "5060a0f8-d33e-4f98-a6ab-16e61ea03c1e",
                            TwoFactorEnabled = false,
                            UserName = "aspadmin"
                        });
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "permission",
                            ClaimValue = "*",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("smallint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles", (string)null);
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.Tea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6b2e090-be68-4f3c-96c0-c62670b44934"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(4869),
                            Name = "Earl Gray",
                            Price = 20m
                        },
                        new
                        {
                            Id = new Guid("55672e16-310a-49c4-a87e-5c429cc783e2"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5649),
                            Name = "Rose Tea",
                            Price = 20m
                        },
                        new
                        {
                            Id = new Guid("dcfdfe8b-d61e-49e9-aa0a-bdf113a4f841"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5652),
                            Name = "English Breakfast Tea",
                            Price = 18m
                        },
                        new
                        {
                            Id = new Guid("ab874d21-0824-4b43-a65d-7fd31a05f5af"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5653),
                            Name = "Big Sur Tea",
                            Price = 25m
                        },
                        new
                        {
                            Id = new Guid("60e8efd0-8f74-49a2-895b-35913a9f05cb"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5654),
                            Name = "Big Sur Tea",
                            Price = 25m
                        },
                        new
                        {
                            Id = new Guid("e3e61b63-f384-4a35-a163-7bde25af7c38"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5661),
                            Name = "Jasmine Pearls",
                            Price = 41m
                        },
                        new
                        {
                            Id = new Guid("c35abbae-4191-4541-8304-3dd071a7cd2c"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5662),
                            Name = "Dragonwell",
                            Price = 30m
                        },
                        new
                        {
                            Id = new Guid("6784be54-7648-469a-b158-f1e1affff931"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5663),
                            Name = "White Peach Tea",
                            Price = 29m
                        },
                        new
                        {
                            Id = new Guid("8b015cb5-ffaa-4efe-a9b3-160c3e7bf1da"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5664),
                            Name = "Vanilla Berry Tea",
                            Price = 21m
                        },
                        new
                        {
                            Id = new Guid("18b4a333-c4d9-4604-b816-71dce6cd6c67"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5665),
                            Name = "Chaga Chai Mushroom Tea",
                            Price = 20m
                        },
                        new
                        {
                            Id = new Guid("023f9bec-d736-4c54-94e8-69257af821e2"),
                            Created = new DateTime(2022, 6, 19, 19, 42, 43, 814, DateTimeKind.Utc).AddTicks(5666),
                            Name = "Naked Pu-erh Tea",
                            Price = 27m
                        });
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppRefreshToken", b =>
                {
                    b.HasOne("SeniorTemplate.Data.Entities.AppUser", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("SeniorTemplate.Data.Entities.AppRole", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserClaim", b =>
                {
                    b.HasOne("SeniorTemplate.Data.Entities.AppUser", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserLogin", b =>
                {
                    b.HasOne("SeniorTemplate.Data.Entities.AppUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserRole", b =>
                {
                    b.HasOne("SeniorTemplate.Data.Entities.AppRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorTemplate.Data.Entities.AppUser", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUserToken", b =>
                {
                    b.HasOne("SeniorTemplate.Data.Entities.AppUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppRole", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SeniorTemplate.Data.Entities.AppUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Roles");

                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
