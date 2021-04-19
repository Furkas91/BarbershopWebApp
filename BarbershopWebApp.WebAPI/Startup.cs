using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.BLL.Implementation;
using BarbershopWebApp.DAL;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.DAL.Implementations;

namespace BarbershopWebApp.WebAPI
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст MobileContext в качестве сервиса в приложение
            services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddControllersWithViews();
            
            services.AddAutoMapper(typeof(Startup));
            
            //BLL
            services.Add(new ServiceDescriptor(typeof(ILoyaltyService), typeof(LoyaltyService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IConsumerService), typeof(ConsumerService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBarberService), typeof(BarberService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IHaircutService), typeof(HaircutService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteService), typeof(NoteService), ServiceLifetime.Scoped));
            
            // DAL
            services.Add(new ServiceDescriptor(typeof(ILoyaltyDAL), typeof(LoyaltyDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IConsumerDAL), typeof(ConsumerDAL), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IBarberDAL), typeof(BarberDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IHaircutDAL), typeof(HaircutDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteDAL), typeof(NoteDAL), ServiceLifetime.Scoped));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}