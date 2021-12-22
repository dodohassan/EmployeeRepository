using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Employee.Data.ConnectionStrings;
using Employee.Data.DbContexts;
using Employee.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApp
{
	public class Startup
	{
		private string defaultEmpDbConnection { get; set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			defaultEmpDbConnection = DataConectionString.LocalEMPDbConnectionString;

		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddDbContext<EmployeesDBContext>(options =>
		    options.UseSqlServer(defaultEmpDbConnection));

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			// Auto Mapper Configurations
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			//Now register our services with Autofac container

			var builder = new ContainerBuilder();

			builder.RegisterModule(new AutoFacConfiguration());

			builder.Populate(services);

			var container = builder.Build();

			// Create the IServiceProvider based on the container.
			return new AutofacServiceProvider(container);

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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
