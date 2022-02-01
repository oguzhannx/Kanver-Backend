using Business.Abstract;
using Business.Adapters.Abstract;
using Business.Adapters.Concrete;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Conctrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
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
            services.AddCors();
            services.AddControllers();

            //USER
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IUserService, UserMan>();

            //BLOODTYPE
            services.AddSingleton<IBloodTypeDal, EfBloodTypeDal>();

            //COMPLA�NT
            services.AddSingleton<IComplaintDal, EfComplaintDal>();
            services.AddSingleton<IComplaintService, ComplaintMan>();

            //ABOUT
            services.AddSingleton<IAboutDal, EfAboutDal>();
            services.AddSingleton<IAboutService, AboutMan>();

            //CONTACT
            services.AddSingleton<IContactDal, EfContactDal>();
            services.AddSingleton<IContactService, ContactMan>();

            //FAQ
            services.AddSingleton<IFaqDal, EfFaqDal>();
            services.AddSingleton<IFaqService, FaqMan>();

            //DONOR
            services.AddSingleton<IDonorDal, EfDonorDal>();
            services.AddSingleton<IDonorService, DonorMan>();

            //ANNOUCEMENT
            services.AddSingleton<IAnnouncementDal, EfAnnouncementDal>();
            services.AddSingleton<IAnnouncementService, AnnouncementMan>();

            //CITY
            services.AddSingleton<ICityDal, EfCityDal>();
            services.AddSingleton<ICityService, CityMan>();

            //Service
            services.AddSingleton(typeof(IMernisServiceAdapter), typeof(MernisServiceAdapter));

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}