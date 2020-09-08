using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("APP") { }

        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<OptionEntity> Options { get; set; }
    }
}
