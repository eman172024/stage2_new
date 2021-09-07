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
            services.AddTransient<IMailInterface, MookMail>();
            services.AddTransient<IExternalMailcs, MookExternalMail>();
            services.AddTransient<IExtrenal_inbox, MooKExernalnbox>();
            services.AddTransient<IMail_Resourcescs, MooKMail_Resourcescs>();
            services.AddTransient<IAdministratorInterface, MockAdministrator>();
            services.AddTransient<ISender, MookSender>();
            services.AddTransient<GenericInterface<Measures, MeasuresDto>, MookMeasures>();
            services.AddTransient<IReplay, MookReplay>();
    
          //  services.AddTransient<GenericInterface<ClasificationSubject, ClasificationSubject>, MookClasificationSubject>();
            services.AddTransient<Idepartment, MocDepartment>();
            services.AddTransient<Generic2<Extrmal_Section, Extrmal_SectionDto>, MocSection>();

            

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

            app.UseAuthorization();
        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          
        }
    }
}
