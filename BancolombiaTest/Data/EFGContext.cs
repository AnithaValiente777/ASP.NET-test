using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancolombiaTest.Models;

namespace BancolombiaTest.Data
{
    public class EFGContext : DbContext
    {
        public EFGContext (DbContextOptions<EFGContext> options)
            : base(options)
        {
        }

        public DbSet<BancolombiaTest.Models.Gerente> Gerente { get; set; }

        public DbSet<BancolombiaTest.Models.Coordinador> Coordinador { get; set; }

        public DbSet<BancolombiaTest.Models.Vendedor> Vendedor { get; set; }

        public DbSet<BancolombiaTest.Models.Segmento> Segmento { get; set; }

        public DbSet<BancolombiaTest.Models.Nivel> Nivel { get; set; }

        public DbSet<BancolombiaTest.Models.Cliente> Cliente { get; set; }
    }
}
