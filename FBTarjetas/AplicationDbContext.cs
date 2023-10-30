using FBTarjetas.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjetas
{
    public class AplicationDbContext: DbContext
    {
         public DbSet<TarjetaCredito> ANGULAR { get; set; }
         public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
