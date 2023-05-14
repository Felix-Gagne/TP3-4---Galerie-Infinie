using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tp3_API.Models;

namespace tp3_API.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            PasswordHasher<User> hasher = new PasswordHasher<User> ();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-11111111",
                UserName = "user1",
                Email = "user1@gmail.com",
                NormalizedEmail = "USER1@GMAIL.COM",
                NormalizedUserName = "USER1"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "User1");
            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-11111112",
                UserName = "user2",
                Email = "user2@gmail.com",
                NormalizedEmail = "USER2@GMAIL.COM",
                NormalizedUserName = "USER2"
            };
            u2.PasswordHash = hasher.HashPassword(u2, "User2");
            builder.Entity<User>().HasData(u1, u2);

            builder.Entity<Galery>().HasData(
                new { Id = 1, Name = "Test Publique", IsPublic = true, FileName = "11111111-1111-1111-1111-111111111111.png", MimeType = "image/png"},
                new { Id = 2, Name = "Test Privée", IsPublic = false, FileName = "11111111-1111-1111-1111-111111111111.png", MimeType = "image/png"}
            );

            builder.Entity<Galery>()
                .HasMany(g => g.AllowedUser)
                .WithMany(u => u.Galery)
                .UsingEntity(e =>
                {

                    e.HasData(new { AllowedUserId = u1.Id, GaleryId = 1 });
                    e.HasData(new { AllowedUserId = u2.Id, GaleryId = 2 });

                });

            builder.Entity<Images>().HasData(
                    new { Id = 1, FileName = "11111111-1111-1111-1111-111111111111.jpg", MimeType = "image/jpg", GaleryId = 1}
                );

            byte[] file = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/original/11111111-1111-1111-1111-111111111111.jpg");
            Image image = Image.Load(file);

            image.Mutate(i =>
                i.Resize(new ResizeOptions()
                {
                    Mode = ResizeMode.Min,
                    Size = new Size()
                    {
                        Width = 300
                    }
                })
            );

            image.Save(Directory.GetCurrentDirectory() + "/images/miniature/11111111-1111-1111-1111-111111111111.jpg");


        }

        public DbSet<tp3_API.Models.Galery> Galery { get; set; } = default!;
        public DbSet<tp3_API.Models.Images> Images { get; set; } = default!;
    }
}
