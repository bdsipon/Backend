using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Contexts
{
    
    public class ParaContext : DbContext
    {
        public ParaContext(DbContextOptions<ParaContext> options)
            : base(options) { }
    
        public DbSet<Para> Para { get; set; }
        public DbSet<ParaLeft> ParaLeft { get; set; }
        public DbSet<ParaRight> ParaRight { get; set; }
    }
}
