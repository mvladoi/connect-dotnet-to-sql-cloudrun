using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data.Common;
using System.Data;
using Polly;




namespace helloworld_csharp
{
    public class Startup
    {





        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var cs = "Uid=postgres;Pwd=root;Host=/cloudsql/run-to-postgres:us-central1:myinstance/;Database=test";
                    await using var conn = new NpgsqlConnection(cs); 
                    await conn.OpenAsync();
                    

                    var sql = "SELECT version()";

                    using var cmd = new NpgsqlCommand(sql, conn);

                    var version = cmd.ExecuteScalar().ToString();
 
                    await context.Response.WriteAsync(version);
                });
            });
        }
    }
}
