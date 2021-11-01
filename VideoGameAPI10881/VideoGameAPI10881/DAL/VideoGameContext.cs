using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI10881.Model;

namespace VideoGameAPI10881.DAL
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options) : base(options)
        {

        }

        public DbSet<Videogame> Videogames { get; set; }
    }
}
