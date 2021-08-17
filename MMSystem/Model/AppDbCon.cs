using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class AppDbCon:DbContext
    {
        public DbSet<Administrator> Administrator { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<External_Mail> External_Mails { get; set; }
       public DbSet<Extrenal_inbox> Extrenal_Inboxes { get; set; }
       public DbSet<Mail> Mails { get; set; }
       public DbSet<Mail_Resourcescs> Mail_Resourcescs { get; set; }
      public DbSet<Reply> Replies { get; set; }
       public DbSet<Reply_Resources> Reply_Resources { get; set; }
       public DbSet<Send_to> Sends { get; set; }
       public DbSet<Extrmal_Section> Extrmal_Sections { get; set; }

        public DbSet<Measures> measures { get; set; }

        public AppDbCon(DbContextOptions<AppDbCon>options):base(options)
        {

        }
    }
}
