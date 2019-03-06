using ExcelTeamplate.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelTeamplate.TeamplateDbContext
{
    public class TeamplateContext : DbContext
    {
        public TeamplateContext(DbContextOptions<TeamplateContext> options)
            :base(options)
        {

        }

        public DbSet<Log> Logs { set; get; }
        public DbSet<Attach> Attaches { set; get; }
        public DbSet<Main> Mains { set; get; }
        public DbSet<Data> Datas { set; get; }
        public DbSet<Field> Fields { set; get; }
    }
}
