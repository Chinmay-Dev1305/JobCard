using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobCard.Entities
{
    public class JobCardContext : DbContext
    {
        public JobCardContext(DbContextOptions<JobCardContext> options) : base(options)
        {

        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<JobCards> JobCards { get; set; }
    }
}
