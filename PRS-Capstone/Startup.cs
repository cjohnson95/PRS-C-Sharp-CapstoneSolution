using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PRS_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Capstone {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            var connStrKey = "PrsDbContextWinhost";

#if DEBUG
            connStrKey = "PrsDbContext";    //lines 30-32 is the manually written code to run when I am running program in debug mode. This says to run the local
#endif                                      //DB vs. the cloud/production one with Winhost at end. When I runn it un "release mode", it'll gray out.

            services.AddDbContext<PRSDbContext>(x => {
                x.UseSqlServer(Configuration.GetConnectionString(connStrKey));  
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.GetRequiredService < IServiceScopeFactory >().CreateScope()) 
                scope.ServiceProvider.GetService<PRSDbContext>().Database.Migrate();
            }



        }
    }
