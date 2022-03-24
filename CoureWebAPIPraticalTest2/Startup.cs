using CoureWebAPIPraticalTest2.Data;
using CoureWebAPIPraticalTest2.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureWebAPIPraticalTest2
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
            services.AddDbContext<CountryDbContext>(option =>option.UseInMemoryDatabase(Configuration.GetConnectionString("CoureDb")));
            services.AddControllers();

            services.AddTransient<CountryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<CountryDbContext>();
            SeedData(context);
        }

        public static void SeedData(CountryDbContext context)
        {
            Country country1 = new Country
            {
                Id = 1,
                Countrycode = "234",
                Name = "Nigeria",
                CountryIso = "NG",
            };

            Country country2 = new Country
            {
                Id = 2,
                Countrycode = "233",
                Name = "Ghana",
                CountryIso = "GH"
            };
            Country country3 = new Country
            {
                Id = 3,
                Countrycode = "229",
                Name = "Benin Republic",
                CountryIso = "BN"
            };
            Country country4 = new Country
            {
                Id = 4,
                Countrycode = "225",
                Name = "Côte d'Ivoire",
                CountryIso = "CIV"
            };

            CountryDetails countryDetails1 = new CountryDetails
            {
                Id = 1,
                CountryId = 1,
                Operator = "MTN Nigeria",
                OperatorCode = "MTN NG"
            };

            CountryDetails countryDetails2 = new CountryDetails
            {
                Id = 2,
                CountryId = 1,
                Operator = "Airtel Nigeria",
                OperatorCode = "ANG"
            };
            CountryDetails countryDetails3 = new CountryDetails
            {
                Id = 3,
                CountryId = 1,
                Operator = "9 mobile Nigeria",
                OperatorCode = "ETN"
            };
            CountryDetails countryDetails4 = new CountryDetails
            {
                Id = 4,
                CountryId = 1,
                Operator = "Globacom Nigeria",
                OperatorCode = "GLO NG"
            };
            CountryDetails countryDetails5 = new CountryDetails
            {
                Id = 5,
                CountryId = 2,
                Operator = "Vodafone Ghana",
                OperatorCode = "Vodafone NG"
            };
            CountryDetails countryDetails6 = new CountryDetails
            {
                Id = 6,
                CountryId = 2,
                Operator = "MTN Ghana",
                OperatorCode = "MTN Ghana"
            };
            CountryDetails countryDetails7 = new CountryDetails
            {
                Id = 7,
                CountryId = 2,
                Operator = "Tigo Ghana",
                OperatorCode = "Tigo Ghana"
            };
            CountryDetails countryDetails8 = new CountryDetails
            {
                Id = 8,
                CountryId = 3,
                Operator = "MTN Benin",
                OperatorCode = "MTN Benin"
            };
            CountryDetails countryDetails9 = new CountryDetails
            {
                Id = 9,
                CountryId = 3,
                Operator = "Moov Benin",
                OperatorCode = "Moov Benin"
            };
            CountryDetails countryDetails10 = new CountryDetails
            {
                Id = 10,
                CountryId = 4,
                Operator = "MTN  Côte d'Ivoire",
                OperatorCode = "MTN CIV"
            };

            context.Country.Add(country1);
            context.Country.Add(country2);
            context.Country.Add(country3);
            context.Country.Add(country4);

            context.CountryDetails.Add(countryDetails1);
            context.CountryDetails.Add(countryDetails2);
            context.CountryDetails.Add(countryDetails3);
            context.CountryDetails.Add(countryDetails4);
            context.CountryDetails.Add(countryDetails5);
            context.CountryDetails.Add(countryDetails6);
            context.CountryDetails.Add(countryDetails7);
            context.CountryDetails.Add(countryDetails8);
            context.CountryDetails.Add(countryDetails9);
            context.CountryDetails.Add(countryDetails10);

            context.SaveChanges();
        }
    }
}
