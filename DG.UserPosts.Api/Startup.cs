using System;
using DG.UserPosts.Business.Posts.Queries.GetList;
using DG.UserPosts.Business.Posts.Queries.GetListByUserId;
using DG.UserPosts.Business.UserPosts.Queries.Get;
using DG.UserPosts.Business.UserPosts.Queries.GetList;
using DG.UserPosts.Business.Users.Queries.Get;
using DG.UserPosts.Business.Users.Queries.GetList;
using DG.UserPosts.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace DG.UserPosts.Api
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
            services.AddScoped<IGetPostListQuery, GetPostListQuery>();
            services.AddScoped<IGetUserListQuery, GetUserListQuery>();
            
            services.AddScoped<IGetPostListByUserIdQuery, GetPostListByUserIdQuery>();
            services.AddScoped<IGetUserQuery, GetUserQuery>();

            services.AddScoped<IGetUsersPostListQuery, GetUsersPostListQuery>();
            services.AddScoped<IGetUserPostsByUserIdQuery, GetUserPostsByUserIdQuery>();

            services.AddRefitClient<IJSONPlaceholderService>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://jsonplaceholder.typicode.com"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
