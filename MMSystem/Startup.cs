using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Services;
using MMSystem.Services.Depart;
using MMSystem.Services.MailServeic;
using MMSystem.Services.MeasuresServeic;
using MMSystem.Services.Section;
using MMSystem.Services.ReplayServeic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMSystem.Services.RoleService;
using MMSystem.Services.Reports;
using MMSystem.Services.Histor;
using MMSystem.Services.DashBords;
using MMSystem.Services.Archives;
using MMSystem.Services.ReceivedMail;

namespace MMSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<AppDbCon>(option => option.UseSqlServer(Configuration.GetConnectionString("AppContext")));
            services.AddScoped<IMailInterface, MookMail>();
            services.AddScoped<IExternalMailcs, MookExternalMail>();
            services.AddScoped<IExtrenal_inbox, MooKExernalnbox>();
            services.AddScoped<IMail_Resourcescs, MooKMail_Resourcescs>();
            services.AddScoped<IAdministratorInterface, MockAdministrator>();
            services.AddScoped<ISender, MookSender>();
            services.AddScoped<IRportInterface,MockReports>();
            services.AddScoped<GenericInterface<Measures, MeasuresDto>, MookMeasures>();
            services.AddScoped<IReplay, MookReplay>();
            services.AddScoped<GenericInterface<Role, RoleDto>, MockRole>();
            services.AddScoped<GenericInterface<ClasificationSubject, ClasificationSubjectDto>, MookClasificationSubject>();
            services.AddScoped<Idepartment, MocDepartment>();
            services.AddScoped<Generic2<Extrmal_Section, Extrmal_SectionDto>, MocSection>();
            services.AddScoped<IHistory, MokHistory>();
            services.AddScoped<IDashBord, MokDashBord>();
            services.AddScoped<IArchives, MokArchives>();
            services.AddScoped<IReceived, MookRecevied>();
            services.AddScoped<GetMailServices, MookGetMail>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseRouting();
            app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();
        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          
        }
    }
}
