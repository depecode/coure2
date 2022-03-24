using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureWebAPIPraticalTest2.Model
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Country> Country { get; set; }
        public DbSet<CountryDetails> CountryDetails { get; set; }
    }
}
