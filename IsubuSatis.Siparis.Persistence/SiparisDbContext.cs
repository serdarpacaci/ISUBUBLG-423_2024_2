﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IsubuSatis.Siparis.Persistence
{
    public class SiparisDbContext : DbContext
    {
        public DbSet<Siparis.Domain.Siparis> Siparisler { get; set; }
        public DbSet<Siparis.Domain.SiparisUrunBilgi> SiparisUrunler { get; set; }
        public DbSet<Siparis.Domain.Address> Adressler { get; set; }
        public SiparisDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
