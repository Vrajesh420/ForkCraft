using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ForkCraft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForkCraft.Data
{
    public class ForkCraftContext : IdentityDbContext
    {
        public ForkCraftContext(DbContextOptions<ForkCraftContext> options)
            : base(options)
        {
        }
        public DbSet<Fork> Fork { get; set; }
    }
}
