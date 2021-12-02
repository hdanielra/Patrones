using Microsoft.EntityFrameworkCore;
using MVCSingleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSingleton.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //La conexión está inicializada en Startup.cs y la cadena está en appsettings.json
        }

        public DbSet<Labels> Labels { get; set; }
    }

}
