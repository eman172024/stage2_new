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
        public DbSet<MailStatus> MailStatuses { get; set; }
        public DbSet<HistortyName> histortyNames { get; set; }
        public DbSet<External_Department> external_Departments { get; set; }



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
                new Role { RoleId = 1, Name = "الصادر", state = true, code = "a" },
                new Role { RoleId=2,Name="اضافة بريد جديد", state=true, code = "b" },
                new Role { RoleId = 3, Name = "اضافة بريد داخلي", state = true,code="c" },
                new Role { RoleId = 4, Name = "اضافة بريد وارد خارجي", state = true, code = "d" },
                new Role { RoleId = 5, Name = "اضافة بريد صادر خارجي", state = true, code = "e" },
                new Role { RoleId = 6, Name = " الرد علي الصادر", state = true, code = "f" },
                new Role { RoleId = 7, Name = " عرض الصورة الصادرة", state = true, code = "g" },
                new Role { RoleId = 10, Name = "الاستلام", state = true, code = "j" },
                new Role { RoleId = 11, Name = "السحب", state = true, code = "k" },
                new Role { RoleId = 12, Name = "الاحصائيات", state = true, code = "l" },
                new Role { RoleId = 13, Name = "تقارير المتابعة", state = true, code = "m" },
                new Role { RoleId = 14, Name = "الوارد", state = true, code = "n" },
                new Role { RoleId = 15, Name = "البحث في البريد الداخلي", state = true, code = "o" },
                new Role { RoleId = 16, Name = "البحث في البريد الوارد الخارجي", state = true, code = "p" },
                new Role { RoleId = 17, Name = "البحث في البريد صادر الخارجي", state = true, code = "q" },
                 new Role { RoleId = 18, Name = "الرد علي الوارد", state = true, code = "r" },
                new Role { RoleId = 19, Name = "عرض الصورة الواردة", state = true, code = "s" },
               new Role { RoleId = 20, Name = "تصوير داخلي", state = true, code = "t" },
                new Role { RoleId = 21, Name = "تصوير  صادر خارجي", state = true, code = "u" },
                new Role { RoleId = 22, Name = "تصوير وارد خارجي", state = true, code = "v" },
                new Role { RoleId = 23, Name = "تعديل الداخلي", state = true, code = "w" },
                new Role { RoleId = 24, Name = "تعديل وارد خارجي", state = true, code = "x" },
                new Role { RoleId = 25, Name = "تعديل صادر خارجي", state = true, code = "y" },
                new Role { RoleId = 26, Name = " ارسال بريد داخلي", state = true, code = "z" },
                new Role { RoleId = 27, Name = " ارسال وارد خارجي", state = true, code = "1" },
                   new Role { RoleId = 28, Name = " ارسال صادر خارجي", state = true, code = "2" },
                   new Role { RoleId = 29, Name = " حذف بريد داخلي", state = true, code = "3" },
                new Role { RoleId = 30, Name = " حذف وارد خارجي", state = true, code = "4" },
                   new Role { RoleId = 31, Name = " حذف صادر خارجي", state = true, code = "5" },
                                      new Role { RoleId = 32, Name = " حذف صورة", state = true, code = "6" },
                                 new Role { RoleId = 33, Name = "  التعديل علي البريد بعد الارسال", state = true, code = "7" }







             )
                ;


            modelBuilder.Entity<Department>().HasData
                (
                
                new Department { Id=  1,  DepartmentName = "الادارة العامة للتحقيق ",perent=0,state=true},
                new Department { Id = 2,  DepartmentName = "لجنة الحضور والانصراف", perent =0, state = true },
                //new Department { Id = 3,  DepartmentName = "الادارة العامة للشؤون الادارية والمالية ", perent =1, state = true },
                //new Department { Id = 4,  DepartmentName = "الادارة العامة للرقابة علي الشركات والمشروعات", perent =1, state = true },

                new Department { Id = 5,  DepartmentName = "الادارة العامة للرقابة علي رئاسة الوزراء", perent =1, state = true },
                //new Department { Id = 6,  DepartmentName = "الادارة العامة للرقابة علي المؤسسات العامة", perent =1, state = true },
                new Department { Id = 8,  DepartmentName = "مكتب مستشاري رئيس الهيئة", perent =1, state = true },
                //new Department { Id = 10, DepartmentName = "الادارة العامة للرقابة علي المصارف", perent =0, state = true },
                new Department { Id = 13, DepartmentName = "مكتب المراجعة  الداخلية", perent =10, state = true },
                new Department { Id = 14, DepartmentName = "مكتب التفتيش وتقييم الاداء ", perent =0, state = true },
                //new Department { Id = 15, DepartmentName = "مكتب الرعاية الصحية", perent =14, state = true },
                new Department { Id = 16, DepartmentName = "مكتب التخطيط", perent =14, state = true },
                new Department { Id = 17, DepartmentName = "مكتب التوثيق وتقنية المعلومات", perent =14, state = true },
                //new Department { Id = 18, DepartmentName = "مكتب متابعة الرقم الوطني", perent =14, state = true },
                new Department { Id = 19, DepartmentName = "مكتب المحفوظات ", perent =14, state = true },
                new Department { Id = 20, DepartmentName = "مكتب الشؤون القانونية ودراسة التشريعات", perent =14, state = true },
                new Department { Id = 21, DepartmentName = "مكتب رئيس الهيئة", perent =0, state = true },
                new Department { Id = 22, DepartmentName = "مكتب وكيل الهيئة", perent =21, state = true },
                //new Department { Id = 24, DepartmentName = "مكتب التدريب", perent = 21, state = true },
                new Department { Id = 25, DepartmentName = "مكتب الشؤون الاعلامية", perent = 0, state = true },

                new Department { Id = 26, DepartmentName = "الادارة العامة للرقابة الخارجية ", perent = 0, state = true },
                new Department { Id = 28, DepartmentName = "لجنة صندوق العاملين", perent = 1, state = true },
                //new Department { Id = 29, DepartmentName = "مكتب الشكاوي والبلاغات   ", perent = 1, state = true },
                //new Department { Id = 30, DepartmentName = "مكتب شؤون الفروع ", perent = 1, state = true },
                //new Department { Id = 31, DepartmentName = "مكتب المتابعة", perent = 1, state = true },
                new Department { Id = 32, DepartmentName = "مكتب التعاون الدولي والتواصل", perent = 1, state = true },
                //new Department { Id = 33, DepartmentName = "الادارة العامة للرقابة علي لجان الازمة واللجان التسييرية والمؤقتة", perent = 1, state = true },
                new Department { Id = 34, DepartmentName = " وحدة الحماية الشخصية", perent = 1, state = true },
                new Department { Id = 35, DepartmentName = "وحدة العلاقات الخاصة بمكتب الرئيس", perent = 1, state = true },
                new Department { Id = 36, DepartmentName = "مكتب التحري والمعلومات", perent = 10, state = true },
                new Department { Id = 38, DepartmentName = "الإدارة العامة للرقابة علي القطاعات الخدمية والأمنية", perent = 14, state = true },
                new Department { Id = 39, DepartmentName = "الإدارة العامة للرقابة علي القطاعات الإنتاجية والبنية الأساسية", perent = 14, state = true },
                new Department { Id = 40, DepartmentName = "الإدارة العامة للرقابة علي القطاعات الاقتصادية والاستثمار", perent = 14, state = true },
                new Department { Id = 41, DepartmentName = "الإدارةالعامة للموارد البشرية", perent = 21, state = true },
                new Department { Id = 42, DepartmentName = "الإدارةالعامة للشؤون الإدارية والخدمات", perent = 21, state = true },
                new Department { Id = 43, DepartmentName = "الإدارةالعامة للشؤون المالية", perent = 21, state = true },

                new Department { Id = 44, DepartmentName = "لجنة الموقع", perent = 10, state = true },
                new Department { Id = 49, DepartmentName = "فرع العزيزية", perent = 0, state = true },
                new Department { Id = 50, DepartmentName = "فرع غرب طرابلس", perent = 14, state = true },
                new Department { Id = 51, DepartmentName = "فرع مصراته", perent = 14, state = true },
                new Department { Id = 52, DepartmentName = "فرع ترهونة", perent = 14, state = true },
                new Department { Id = 53, DepartmentName = "فرع الزنتان", perent = 0, state = true },
                new Department { Id = 54, DepartmentName = "لجنة ربط الفروع ", perent = 0, state = true },
                new Department { Id = 55, DepartmentName = "لجنة متابعة تنفيد مبني الهيئة   ", perent = 0, state = true },
                new Department { Id = 56, DepartmentName = "فرع شرق طرابلس", perent = 0, state = true }
                 
                                         );
            

            modelBuilder.Entity<Extrmal_Section>().HasData(

                new Extrmal_Section
                {
                    id = 1,
                    type = 1,
                    Section_Name = "فروع الهيئة ",
                    perent = 0,
                    state = true
                }
                //,
                //new Extrmal_Section
                //{
                //    id = 2,
                //    type = 1,
                //    Section_Name = "فرع سبها ",
                //    perent =1,
                //    state = true
                //}, 
                //new Extrmal_Section
                //{
                //    id = 3,
                //    type = 1,
                //    Section_Name = "فرع مصراته ",
                //    perent = 1,
                //    state = true
                //},

                //new Extrmal_Section
                //{
                //    id = 4,
                //    type = 2,
                //    Section_Name = "الشركات الوطنية ",
                //    perent = 0,
                //    state = true
                //},
                //new Extrmal_Section
                //{
                //    id = 5,
                //    type = 2,
                //    Section_Name = "الشركة العامة للكهرباء  ",
                //    perent =4,
                //    state = true
                //},
                //new Extrmal_Section
                // {
                //     id = 6,
                //     type = 2,
                //     Section_Name = "شركة المياه والصرف الصحي ",
                //     perent = 4,
                //     state = true
                // },

                //new Extrmal_Section
                //{
                //    id = 7,
                //    type = 2,
                //    Section_Name = "الشركات الاجنبية ",
                //    perent = 0,
                //    state = true
                //},
                //new Extrmal_Section
                // {
                //     id = 8,
                //     type = 2,
                //     Section_Name = "Oil and Gas",
                //     perent = 7,
                //     state = true
                // },
                //new Extrmal_Section
                //{
                //    id = 9,
                //    type = 2,
                //    Section_Name = "AVA",
                //    perent = 7,
                //    state = true
                //},

                //new Extrmal_Section
                //{
                //    id = 10,
                //    type = 3,
                //    Section_Name = "ذات المسؤولية المحدودة",
                //    perent = 0,
                //    state = true
                //},
                //new Extrmal_Section
                //{
                //    id = 11,
                //    type = 3,
                //    Section_Name = "النمو التقني",
                //    perent = 10,
                //    state = true
                //}

                );

            modelBuilder.Entity<MailStatus>().HasData(
            new MailStatus { 
            
            flag=1,sent="لم ترسل",state=true,inbox="",
            },
            new MailStatus
            {

                flag = 2,
                sent = "لم تقرأ",
                state = true,inbox="لم يتم قراءة البريد"
            }, 
            new MailStatus
            {

                flag = 3,
                sent = "قرأت ",
                state = true,inbox = "تم قراءة البريد"
            },
            new MailStatus
            {

                flag = 4,
                sent = "تم الرد",
                state = true,
                inbox = "تم الرد من قيلك "
            }, new MailStatus
            {

                flag = 5,
                sent = "تم الرد من قبلك",
                state = true ,
                inbox = "يوجد رد جديد من الادارة المرسلة"
            },
            new MailStatus
            {

                flag = 6,
                sent = "تم السحب",
                state = true,
                inbox = "تم سحب البريد من قبلك"
            });

            modelBuilder.Entity<HistortyName>().HasData(new HistortyName { 
            ID=1,
            name="اضافة بريد"
            
            }, new HistortyName
            {
                ID = 2,
                name = " تعديل بريد"

            }, new HistortyName
            {
                ID = 3,
                name = "حدف بريد"

            },

            new HistortyName
            {
                ID = 4,
                name = "اضافة صورة"

            },
            new HistortyName
            {
                ID =5,
                name = "حدف صورة"

            },

             new HistortyName
             {
                 ID = 6,
                 name = "اضافة رد"

             },
               new HistortyName
               {
                   ID = 7,
                   name = "حذف رد"

               }
               ,
               new HistortyName
               {
                   ID = 8,
                   name = "  اضافة ادارة"

               }
                              ,
               new HistortyName
               {
                   ID = 9,
                   name = "  حدف ادارة"

               },
               new HistortyName
               {
                   ID = 10,
                   name = "اضافة مستخدم "

               },
               new HistortyName
               {
                   ID = 11,

                   name = "تعديل مستخدم"


               },
               new HistortyName
               {
                   ID = 12,
                   name = "  الغاء تفعيل مستخدم"

               }
               ,
               new HistortyName
               {
                   ID = 13,
                   name = " تم عرض الصورة "

               }
                 ,
               new HistortyName
               {
                   ID = 14,
                   name = " ارسال بريد "

               }

               ,
               new HistortyName
               {
                   ID = 15,
                   name = " قراءة البريد"

               },
               new HistortyName
               {
                   ID = 16,
                   name = " مرفقات"

               },
                  new HistortyName
                  {
                      ID = 17,
                      name = " عدد النسخ"

                  }  , new HistortyName
                  {
                      ID = 18,
                      name = "طباعة حافظة"

                  }, new HistortyName
                  {
                      ID = 19,
                      name = "تسجيل الدخول"

                  }, new HistortyName
                  {
                      ID = 20,
                      name = "اضافة صورة رد"

                  }, new HistortyName
                  {
                      ID = 21,
                      name = "طباعة مستندات الرد"

                  }, new HistortyName
                  {
                      ID = 22,
                      name = "طباعة مستندات البريد  "

                  }, new HistortyName
                  {
                      ID = 23,
                      name = "عرض مستندات الرد  "

                  }, new HistortyName
                  {
                      ID = 24,
                      name = "التسليم "

                  }, new HistortyName
                  {
                      ID = 25,
                      name = "ملاحظات  في المحفوظات "

                  }




            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
