using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whirlpool.Models;

namespace Whirlpool.ForumData
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public DbSet<SubForum> SubForums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Thread> Threads { get; set; }
    }
}
