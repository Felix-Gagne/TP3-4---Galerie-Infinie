using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<tp3_API.Models.Galery> Galery { get; set; } = default!;
    }
}
