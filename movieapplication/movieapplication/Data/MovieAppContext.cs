using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movieapplication.Models;

namespace movieapplication.Data
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext (DbContextOptions<MovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<movieapplication.Models.movie> movie { get; set; }
    }
}
