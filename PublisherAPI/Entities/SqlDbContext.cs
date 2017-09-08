using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PublisherWebAPI.Entities
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
                
        }
    }
}
