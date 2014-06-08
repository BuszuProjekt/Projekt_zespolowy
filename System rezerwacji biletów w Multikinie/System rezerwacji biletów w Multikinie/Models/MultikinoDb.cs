using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace System_rezerwacji_biletów_w_Multikinie.Models
{
    public class MultikinoDb:DbContext
    {
        public MultikinoDb(): base("DefaultConnection") {}
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Seans> Seanse { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<Bilet> Bilety { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}