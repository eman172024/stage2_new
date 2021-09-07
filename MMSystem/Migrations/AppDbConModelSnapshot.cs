﻿// <auto-generated />
using System;
using MMSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMSystem.Migrations
{
    [DbContext(typeof(AppDbCon))]
    partial class AppDbConModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMSystem.Model.Administrator", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstMACAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecandMACAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nationalNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("MMSystem.Model.ClasificationSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("clasifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "شكوى",
                            state = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "مقال صحفي",
                            state = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "ادارية",
                            state = true
                        },
                        new
                        {
                            Id = 4,
                            Name = "قرارات",
                            state = true
                        },
                        new
                        {
                            Id = 5,
                            Name = "اجتماعات",
                            state = true
                        },
                        new
                        {
                            Id = 6,
                            Name = "اخرى",
                            state = true
                        },
                        new
                        {
                            Id = 7,
                            Name = "تعميم",
                            state = true
                        });
                });

            modelBuilder.Entity("MMSystem.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("perent")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentName = "مكتب رئيس الهيئة ",
                            perent = 0,
                            state = true
                        },
                        new
                        {
                            Id = 2,
                            DepartmentName = "مكتب مستشاري رئيس الهيئة",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 3,
                            DepartmentName = "مكتب الشؤون القانونية ودراسة التشريعات",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 4,
                            DepartmentName = "مكتب التفتيش وتقييم الاداء",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 5,
                            DepartmentName = "مكتب التخطيط",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 6,
                            DepartmentName = "مكتب التعاون الدولي والتواضل",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 7,
                            DepartmentName = "مكتب المراجعة الداخلية",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 8,
                            DepartmentName = "وحدة الحماية الشخصية",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 9,
                            DepartmentName = "وحدة العلاقات الخاصة بمكتب الرئيس",
                            perent = 1,
                            state = true
                        },
                        new
                        {
                            Id = 10,
                            DepartmentName = "مكتب وكيل الهيئة",
                            perent = 0,
                            state = true
                        },
                        new
                        {
                            Id = 11,
                            DepartmentName = "مكتب التوثيق وتقنية المعلومات",
                            perent = 10,
                            state = true
                        },
                        new
                        {
                            Id = 12,
                            DepartmentName = "مكتب التحري والمعلومات",
                            perent = 10,
                            state = true
                        },
                        new
                        {
                            Id = 13,
                            DepartmentName = "مكتب الشؤون الإعلامية",
                            perent = 10,
                            state = true
                        },
                        new
                        {
                            Id = 14,
                            DepartmentName = "الإدارات العامة الفنية والرقابية",
                            perent = 0,
                            state = true
                        },
                        new
                        {
                            Id = 15,
                            DepartmentName = "الإدارة العامة للتحقيق",
                            perent = 14,
                            state = true
                        },
                        new
                        {
                            Id = 16,
                            DepartmentName = "الإدارة العامة للرقابة على رئاسة الوزراء",
                            perent = 14,
                            state = true
                        },
                        new
                        {
                            Id = 17,
                            DepartmentName = "الإدارة العامة للرقابة علي القطاعات الخدمية والأمنية",
                            perent = 14,
                            state = true
                        },
                        new
                        {
                            Id = 18,
                            DepartmentName = "الإدارة العامة للرقابة علي القطاعات الإنتاجية والبنية الأساسية",
                            perent = 14,
                            state = true
                        },
                        new
                        {
                            Id = 19,
                            DepartmentName = "الإدارة العامة للرقابة علي القطاعات الاقتصادية والاستثمار",
                            perent = 14,
                            state = true
                        },
                        new
                        {
                            Id = 20,
                            DepartmentName = "الإدارة العامة للرقابة علي قطاع الخارجية",
                            perent = 14,
                            state = true
                        },
                        new
                        {
                            Id = 21,
                            DepartmentName = "الإدارات العامة الخدمية",
                            perent = 0,
                            state = true
                        },
                        new
                        {
                            Id = 22,
                            DepartmentName = "الإدارةالعامة للموارد البشرية",
                            perent = 21,
                            state = true
                        },
                        new
                        {
                            Id = 23,
                            DepartmentName = "الإدارةالعامة للشؤون الإدارية والخدمات",
                            perent = 21,
                            state = true
                        },
                        new
                        {
                            Id = 24,
                            DepartmentName = "الإدارةالعامة للشؤون المالية",
                            perent = 21,
                            state = true
                        });
                });

            modelBuilder.Entity("MMSystem.Model.External_Mail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<int>("Sectionid")
                        .HasColumnType("int");

                    b.Property<int>("action")
                        .HasColumnType("int");

                    b.Property<string>("action_required_by_the_entity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MailID")
                        .IsUnique();

                    b.HasIndex("Sectionid");

                    b.ToTable("External_Mails");
                });

            modelBuilder.Entity("MMSystem.Model.Extrenal_inbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Send_time")
                        .HasColumnType("datetime2");

                    b.Property<int>("action")
                        .HasColumnType("int");

                    b.Property<int>("entity_reference_number")
                        .HasColumnType("int");

                    b.Property<int>("procedure_type")
                        .HasColumnType("int");

                    b.Property<string>("section_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("to")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MailID")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("Extrenal_Inboxes");
                });

            modelBuilder.Entity("MMSystem.Model.Extrmal_Section", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Section_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("perent")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Extrmal_Sections");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Section_Name = "فروع الهيئة ",
                            perent = 0,
                            state = true,
                            type = 1
                        },
                        new
                        {
                            id = 2,
                            Section_Name = "فرغ سبها ",
                            perent = 1,
                            state = true,
                            type = 1
                        },
                        new
                        {
                            id = 3,
                            Section_Name = "فرع مصراته ",
                            perent = 1,
                            state = true,
                            type = 1
                        },
                        new
                        {
                            id = 4,
                            Section_Name = "الشركات الوطنية ",
                            perent = 0,
                            state = true,
                            type = 2
                        },
                        new
                        {
                            id = 5,
                            Section_Name = "الشركة العامة للكهرباء  ",
                            perent = 4,
                            state = true,
                            type = 2
                        },
                        new
                        {
                            id = 6,
                            Section_Name = "شركة المياه والصرف الصحي ",
                            perent = 4,
                            state = true,
                            type = 2
                        },
                        new
                        {
                            id = 7,
                            Section_Name = "الشركات الاجنبية ",
                            perent = 0,
                            state = true,
                            type = 2
                        },
                        new
                        {
                            id = 8,
                            Section_Name = "Oil and Gas",
                            perent = 7,
                            state = true,
                            type = 2
                        },
                        new
                        {
                            id = 9,
                            Section_Name = "AVA",
                            perent = 7,
                            state = true,
                            type = 2
                        },
                        new
                        {
                            id = 10,
                            Section_Name = "ذات المسؤولية المحدودة",
                            perent = 0,
                            state = true,
                            type = 3
                        },
                        new
                        {
                            id = 11,
                            Section_Name = "النمو التقني",
                            perent = 10,
                            state = true,
                            type = 3
                        });
                });

            modelBuilder.Entity("MMSystem.Model.Mail", b =>
                {
                    b.Property<int>("MailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionRequired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Of_Mail")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department_Id")
                        .HasColumnType("int");

                    b.Property<int>("Genaral_inbox_Number")
                        .HasColumnType("int");

                    b.Property<int>("Genaral_inbox_year")
                        .HasColumnType("int");

                    b.Property<int>("Mail_Number")
                        .HasColumnType("int");

                    b.Property<string>("Mail_Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clasification")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("MailID");

                    b.HasIndex("userId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("MMSystem.Model.Mail_Resourcescs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.Property<string>("path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MailID");

                    b.ToTable("Mail_Resourcescs");
                });

            modelBuilder.Entity("MMSystem.Model.Measures", b =>
                {
                    b.Property<int>("MeasuresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeasuresName")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("MeasuresId");

                    b.ToTable("measures");

                    b.HasData(
                        new
                        {
                            MeasuresId = 1,
                            MeasuresName = "للعلم",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 2,
                            MeasuresName = "للرأي",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 3,
                            MeasuresName = "للاجراء",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 4,
                            MeasuresName = "للدراسة",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 5,
                            MeasuresName = "للاختصاص",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 6,
                            MeasuresName = "للبحث والاشادة",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 7,
                            MeasuresName = "لاعداد موقف",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 8,
                            MeasuresName = "للمتابعة",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 9,
                            MeasuresName = "للتحقيق",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 10,
                            MeasuresName = "لامانع",
                            state = true
                        },
                        new
                        {
                            MeasuresId = 11,
                            MeasuresName = "للاهتمام",
                            state = true
                        });
                });

            modelBuilder.Entity("MMSystem.Model.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("To")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("mail_detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("send_ToId")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("ReplyId");

                    b.HasIndex("send_ToId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("MMSystem.Model.Reply_Resources", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ReplyId")
                        .HasColumnType("int");

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.Property<string>("path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ReplyId");

                    b.ToTable("Reply_Resources");
                });

            modelBuilder.Entity("MMSystem.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "الإطلاع على السري"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "استخدام الوارد الخارجي"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "ارسال البريد الى"
                        },
                        new
                        {
                            RoleId = 4,
                            Name = "الإطلاع على التقرير الإحصائى"
                        },
                        new
                        {
                            RoleId = 5,
                            Name = "الصادر الجديد"
                        },
                        new
                        {
                            RoleId = 6,
                            Name = "كتابة اجراءالأمين للرسالة"
                        },
                        new
                        {
                            RoleId = 7,
                            Name = "الإطلاع على تقرير المتابعة"
                        },
                        new
                        {
                            RoleId = 8,
                            Name = "الاستلام والسحب"
                        },
                        new
                        {
                            RoleId = 9,
                            Name = "عرض الصورة"
                        },
                        new
                        {
                            RoleId = 10,
                            Name = "الإطلاع على الوارد الجديد"
                        },
                        new
                        {
                            RoleId = 11,
                            Name = "استخدام الصادر الخارجي"
                        },
                        new
                        {
                            RoleId = 12,
                            Name = "الإطلاع على الردود السابقة"
                        },
                        new
                        {
                            RoleId = 13,
                            Name = "اعادة الارسال"
                        },
                        new
                        {
                            RoleId = 14,
                            Name = "الرد على الوار الجديد"
                        },
                        new
                        {
                            RoleId = 15,
                            Name = "ردود الإدارات الفرعية"
                        },
                        new
                        {
                            RoleId = 16,
                            Name = "استخدام البريد الداخلي"
                        });
                });

            modelBuilder.Entity("MMSystem.Model.Send_to", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Send_time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<bool>("flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("time_of_read")
                        .HasColumnType("datetime2");

                    b.Property<int>("to")
                        .HasColumnType("int");

                    b.Property<int>("type_of_send")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MailID");

                    b.ToTable("Sends");
                });

            modelBuilder.Entity("MMSystem.Model.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("userRoles");
                });

            modelBuilder.Entity("MMSystem.Model.Administrator", b =>
                {
                    b.HasOne("MMSystem.Model.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MMSystem.Model.External_Mail", b =>
                {
                    b.HasOne("MMSystem.Model.Mail", "Mail")
                        .WithOne("external_Mail")
                        .HasForeignKey("MMSystem.Model.External_Mail", "MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MMSystem.Model.Extrmal_Section", "Section")
                        .WithMany("External_Mails")
                        .HasForeignKey("Sectionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MMSystem.Model.Extrenal_inbox", b =>
                {
                    b.HasOne("MMSystem.Model.Mail", "Mail")
                        .WithOne("extrenal_Inbox")
                        .HasForeignKey("MMSystem.Model.Extrenal_inbox", "MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MMSystem.Model.Extrmal_Section", "Section")
                        .WithMany("Extrenal_Inboxes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MMSystem.Model.Mail", b =>
                {
                    b.HasOne("MMSystem.Model.Administrator", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MMSystem.Model.Mail_Resourcescs", b =>
                {
                    b.HasOne("MMSystem.Model.Mail", "Mail")
                        .WithMany()
                        .HasForeignKey("MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");
                });

            modelBuilder.Entity("MMSystem.Model.Reply", b =>
                {
                    b.HasOne("MMSystem.Model.Send_to", "send_To")
                        .WithMany("replies")
                        .HasForeignKey("send_ToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("send_To");
                });

            modelBuilder.Entity("MMSystem.Model.Reply_Resources", b =>
                {
                    b.HasOne("MMSystem.Model.Reply", "Reply")
                        .WithMany("_Resources")
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reply");
                });

            modelBuilder.Entity("MMSystem.Model.Send_to", b =>
                {
                    b.HasOne("MMSystem.Model.Mail", "Mail")
                        .WithMany()
                        .HasForeignKey("MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");
                });

            modelBuilder.Entity("MMSystem.Model.UserRoles", b =>
                {
                    b.HasOne("MMSystem.Model.Role", "Role")
                        .WithMany("userRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MMSystem.Model.Administrator", "User")
                        .WithMany("userRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MMSystem.Model.Administrator", b =>
                {
                    b.Navigation("userRoles");
                });

            modelBuilder.Entity("MMSystem.Model.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MMSystem.Model.Extrmal_Section", b =>
                {
                    b.Navigation("External_Mails");

                    b.Navigation("Extrenal_Inboxes");
                });

            modelBuilder.Entity("MMSystem.Model.Mail", b =>
                {
                    b.Navigation("external_Mail");

                    b.Navigation("extrenal_Inbox");
                });

            modelBuilder.Entity("MMSystem.Model.Reply", b =>
                {
                    b.Navigation("_Resources");
                });

            modelBuilder.Entity("MMSystem.Model.Role", b =>
                {
                    b.Navigation("userRoles");
                });

            modelBuilder.Entity("MMSystem.Model.Send_to", b =>
                {
                    b.Navigation("replies");
                });
#pragma warning restore 612, 618
        }
    }
}
