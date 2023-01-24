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
using MMSystem.Hubs;
using System.Net.WebSockets;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace MMSystem
{
    public class Startup
    {
        private ConcurrentDictionary<string, WebSocket> _conn = new ConcurrentDictionary<string, WebSocket>();
        WebSocketReceiveResult result;
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
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //*******************

            var wsoption = new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120) };
            app.UseWebSockets(wsoption);
            app.Use(async (context, next) =>
            {
                                
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket websocket = await context.WebSockets.AcceptWebSocketAsync();
                    var id = Guid.NewGuid().ToString();
                    var str = _conn.TryAdd(id, websocket);
                    await senid(websocket, id);
                    await resivemassege(websocket, async (result, buffer) =>
                    {
                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            string msg = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                                                       
                            await resm(msg);
                         
                            return;
                        }
                        else if (result.MessageType == WebSocketMessageType.Close)
                        {
                            
                            string id1 = _conn.FirstOrDefault(x => x.Value == websocket).Key;
                            _conn.TryRemove(id1, out WebSocket sockt1);
                            await sockt1.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                            return;
                        }
                    });
                }
               
                else
                {
                    await next();
                }
            });
            //*************************


            app.UseRouting();
           app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
          //   app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

         //  app.UseCors(x => x.WithOrigins("http://mail").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
          
       //    app.UseCors(x => x.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseSignalR(route =>
            {
                route.MapHub<Testhub>("/api/testhub");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          
        }


        //*****************
        public async Task resm(string m)
        
        {

          //  try
           // {
                var obj11 = JsonConvert.DeserializeObject<dynamic>(m);
                          
                var iidd = obj11.keyid.Value;


            var count = _conn.Values;

            var tt = _conn.FirstOrDefault(y => y.Key == iidd);
            if (tt.Value != null)
            {
                if (tt.Value.State == WebSocketState.Open)
                    await tt.Value.SendAsync(Encoding.UTF8.GetBytes(m), WebSocketMessageType.Text, true, CancellationToken.None);

            }
            //    foreach (var c in _conn.Values)
            //{
            //    var xx = _conn.FirstOrDefault(x => x.Value == c).Key;
            //   // if (tt.Value.State == WebSocketState.Open)
            //      if (c.State == WebSocketState.Open)
            //    {
            //        if (xx == iidd)
            //        {
            //            await c.SendAsync(Encoding.UTF8.GetBytes(m), WebSocketMessageType.Text, true, CancellationToken.None);
            //         //   await tt.Value.SendAsync(Encoding.UTF8.GetBytes(m), WebSocketMessageType.Text, true, CancellationToken.None);

            //        }
            //    }
            //}
            //***********14/1/2023
            //foreach (var c in _conn.Values)
            //{
            //    var xx = _conn.FirstOrDefault(x => x.Value == c).Key;

            //    if (c.State == WebSocketState.Open)
            //***********end 14/1/2023

            //  if (tt.Value.State == WebSocketState.Open)
            //  {
            //*********14/1/2023
            //if (xx == iidd)
            //{
            //    await c.SendAsync(Encoding.UTF8.GetBytes(m), WebSocketMessageType.Text, true, CancellationToken.None);
            //}
            //*****end 14/1/2023
            //       await tt.Value.SendAsync(Encoding.UTF8.GetBytes(m), WebSocketMessageType.Text, true, CancellationToken.None);

            // }
            // }
            //  }
            //   catch { Console.WriteLine("error in resm"); }
        }
        //******************
        private async Task senid(WebSocket socket, string id)
        {
            var count1 = _conn.Values.Count();
            //try
            //{
                string json = @"
                       {
                          ""index"":1,
                          ""l"":0,
                           ""count1"":""" + count1 + @""",
                           ""keyid"":""" + id + @"""
                        }";
           
            var buffer = Encoding.UTF8.GetBytes(json);
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

            //}
            //catch { Console.WriteLine("error in senid"); }
        }

        //************************************************************
        private async Task resivemassege(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handelms)
        {

           try
           {
                var buffer = new byte[1024 * 100 * 5 * 1000];
                while (socket.State == WebSocketState.Open)
                {
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    handelms(result, buffer);
                }

            }
            catch (Exception ex)
            {
                foreach (var x1 in _conn.Values)
                {
                    if (x1.State == WebSocketState.Aborted)
                    {
                        string id2 = _conn.FirstOrDefault(x => x.Value == x1).Key;
                        _conn.TryRemove(id2, out WebSocket sockt2);
                       
                    }

                }
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);

            }
            //***********************************************************
        }
        }
}
