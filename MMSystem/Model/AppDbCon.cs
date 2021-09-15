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
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> userRoles { get; set; }
        public DbSet<Historyes> History { get; set; }

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
            modelBuilder.Entity<ClasificationSubject>().HasData(
                
                new ClasificationSubject() {Id=1,Name="شكوى" ,state=true},
                new ClasificationSubject() { Id = 2, Name = "مقال صحفي", state = true },
                new ClasificationSubject() { Id = 3, Name = "ادارية", state = true },
                new ClasificationSubject() { Id = 4, Name = "قرارات", state = true },
                new ClasificationSubject() { Id = 5, Name = "اجتماعات", state = true },
                new ClasificationSubject() { Id = 6, Name = "اخرى", state = true },
                new ClasificationSubject() { Id = 7, Name = "تعميم", state = true });



            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId=1,Name="الإطلاع على السري",
                state=true},
                new Role { RoleId = 2, Name = "استخدام الوارد الخارجي", state = true },
                new Role { RoleId = 3, Name = "ارسال البريد الى", state = true },
                new Role { RoleId = 4, Name = "الإطلاع على التقرير الإحصائى", state = true },
                new Role { RoleId = 5, Name = "الصادر الجديد", state = true },
                new Role { RoleId = 6, Name = "كتابة اجراءالأمين للرسالة", state = true },
                new Role { RoleId = 7, Name = "الإطلاع على تقرير المتابعة", state = true },
                new Role { RoleId = 8, Name = "الاستلام والسحب", state = true },
                new Role { RoleId = 9, Name = "عرض الصورة", state = true },
                new Role { RoleId = 10, Name = "الإطلاع على الوارد الجديد", state = true },
                new Role { RoleId = 11, Name = "استخدام الصادر الخارجي", state = true },
                new Role { RoleId = 12, Name = "الإطلاع على الردود السابقة", state = true },
                new Role { RoleId = 13, Name = "اعادة الارسال", state = true },
                new Role { RoleId = 14, Name = "الرد على الوار الجديد", state = true },
                new Role { RoleId = 15, Name = "ردود الإدارات الفرعية", state = true },
                new Role { RoleId = 16, Name = "استخدام البريد الداخلي", state = true },
                 new Role { RoleId = 17, Name = "الداخلي", state = true },
                new Role { RoleId = 18, Name = "وارد خارجي", state = true })
                ;


            modelBuilder.Entity<Department>().HasData
                (
                
                new Department { Id=1,DepartmentName="مكتب رئيس الهيئة ",perent=0,state=true},
                new Department { Id =2, DepartmentName = "مكتب مستشاري رئيس الهيئة", perent =1, state = true },
                new Department { Id =3, DepartmentName = "مكتب الشؤون القانونية ودراسة التشريعات", perent =1, state = true },
                new Department { Id =4, DepartmentName = "مكتب التفتيش وتقييم الاداء", perent =1, state = true },
                new Department { Id =5, DepartmentName = "مكتب التخطيط", perent =1, state = true },
                 new Department { Id =6, DepartmentName = "مكتب التعاون الدولي والتواضل", perent =1, state = true },
                 new Department { Id =7, DepartmentName = "مكتب المراجعة الداخلية", perent =1, state = true },
                new Department { Id =8, DepartmentName = "وحدة الحماية الشخصية", perent =1, state = true },
                new Department { Id =9, DepartmentName = "وحدة العلاقات الخاصة بمكتب الرئيس", perent =1, state = true },
                 new Department { Id =10, DepartmentName = "مكتب وكيل الهيئة", perent =0, state = true },
                 new Department { Id =11, DepartmentName = "مكتب التوثيق وتقنية المعلومات", perent =10, state = true },
                 new Department { Id = 12, DepartmentName = "مكتب التحري والمعلومات", perent =10, state = true },
                new Department { Id =13, DepartmentName = "مكتب الشؤون الإعلامية", perent =10, state = true },
                 new Department { Id = 14, DepartmentName = "الإدارات العامة الفنية والرقابية", perent =0, state = true },
                 new Department { Id = 15, DepartmentName = "الإدارة العامة للتحقيق", perent =14, state = true },
                   new Department { Id = 16, DepartmentName = "الإدارة العامة للرقابة على رئاسة الوزراء", perent =14, state = true },
                new Department { Id = 17, DepartmentName = "الإدارة العامة للرقابة علي القطاعات الخدمية والأمنية", perent =14, state = true },
                 new Department { Id = 18, DepartmentName = "الإدارة العامة للرقابة علي القطاعات الإنتاجية والبنية الأساسية", perent =14, state = true },
                 new Department { Id = 19, DepartmentName = "الإدارة العامة للرقابة علي القطاعات الاقتصادية والاستثمار", perent =14, state = true },
                  new Department { Id = 20, DepartmentName = "الإدارة العامة للرقابة علي قطاع الخارجية", perent =14, state = true },
                 new Department { Id = 21, DepartmentName = "الإدارات العامة الخدمية", perent =0, state = true },
                 new Department { Id = 22, DepartmentName = "الإدارةالعامة للموارد البشرية", perent =21, state = true },
                 new Department { Id = 23, DepartmentName = "الإدارةالعامة للشؤون الإدارية والخدمات", perent = 21, state = true },
                 new Department { Id = 24, DepartmentName = "الإدارةالعامة للشؤون المالية", perent = 21, state = true },
              new Department { Id = 25, DepartmentName = "المحفوظات", perent = 0, state = true }

                                         );


            modelBuilder.Entity<Extrmal_Section>().HasData(

                new Extrmal_Section
                {
                    id = 1,
                    type = 1,
                    Section_Name = "فروع الهيئة ",
                    perent=0,
                    state=true
                },
                new Extrmal_Section
                {
                    id = 2,
                    type = 1,
                    Section_Name = "فرغ سبها ",
                    perent =1,
                    state = true
                }, 
                new Extrmal_Section
                {
                    id = 3,
                    type = 1,
                    Section_Name = "فرع مصراته ",
                    perent = 1,
                    state = true
                },

                new Extrmal_Section
                {
                    id = 4,
                    type = 2,
                    Section_Name = "الشركات الوطنية ",
                    perent = 0,
                    state = true
                },
                new Extrmal_Section
                {
                    id = 5,
                    type = 2,
                    Section_Name = "الشركة العامة للكهرباء  ",
                    perent =4,
                    state = true
                },
                new Extrmal_Section
                 {
                     id = 6,
                     type = 2,
                     Section_Name = "شركة المياه والصرف الصحي ",
                     perent = 4,
                     state = true
                 },
                 
                new Extrmal_Section
                {
                    id = 7,
                    type = 2,
                    Section_Name = "الشركات الاجنبية ",
                    perent = 0,
                    state = true
                },
                new Extrmal_Section
                 {
                     id = 8,
                     type = 2,
                     Section_Name = "Oil and Gas",
                     perent = 7,
                     state = true
                 },
                new Extrmal_Section
                {
                    id = 9,
                    type = 2,
                    Section_Name = "AVA",
                    perent = 7,
                    state = true
                },

                new Extrmal_Section
                {
                    id = 10,
                    type = 3,
                    Section_Name = "ذات المسؤولية المحدودة",
                    perent = 0,
                    state = true
                },
                new Extrmal_Section
                {
                    id = 11,
                    type = 3,
                    Section_Name = "النمو التقني",
                    perent = 10,
                    state = true
                }

                ); 

            base.OnModelCreating(modelBuilder);
        }


    }
}
