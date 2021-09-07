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
        public DbSet<ClasificationSubject> clasifications { get; set; }
        public DbSet<Measures> measures { get; set; }

        public AppDbCon(DbContextOptions<AppDbCon>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measures>().HasData(
              new Measures { MeasuresId=1,   MeasuresName="للعلم",state=true},
              new Measures { MeasuresId = 2, MeasuresName = "للرأي", state = true },
              new Measures { MeasuresId = 3, MeasuresName = "للاجراء", state = true },
              new Measures { MeasuresId = 4, MeasuresName = "للدراسة", state = true },
              new Measures { MeasuresId = 5, MeasuresName = "للاختصاص", state = true },
              new Measures { MeasuresId = 6, MeasuresName = "للبحث والاشادة", state = true },
              new Measures { MeasuresId = 7, MeasuresName = "لاعداد موقف", state = true },
              new Measures { MeasuresId = 8, MeasuresName = "للمتابعة", state = true },
              new Measures { MeasuresId = 9, MeasuresName = "للتحقيق", state = true },
              new Measures { MeasuresId = 10, MeasuresName = "لامانع", state = true },
            new Measures { MeasuresId = 11, MeasuresName = "للاهتمام", state = true });

           

           
            base.OnModelCreating(modelBuilder);
        }


    }
}
