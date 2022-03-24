using CoureWebAPIPraticalTest2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureWebAPIPraticalTest2.Data
{
    public class CountryRepository
    {
        private readonly CountryDbContext _context;

        public CountryRepository(CountryDbContext context)
        {
            _context = context;
        }

        public DbSet<Country> All()
        {
            return _context.Country;
        }

        public Object Query(string s, string sort, int? queryPage)
        {
            var query = (from countries
                         in _context.Country
                         select countries);

            if(!string.IsNullOrEmpty(s))
            {
                query = query.Where(c => c.Countrycode.Contains(s));
            }

            if(sort == "asc")
            {
                query = query.OrderBy(c => c.Name);
            }

            else if(sort == "desc")
            {
                query = query.OrderByDescending(c => c.Name);
            }

            int perPage = 2;
            int page = queryPage.GetValueOrDefault(1) == 0 ? 1 : queryPage.GetValueOrDefault(1);
            var total = query.Count();

            return new
            {
                data = query.Take(perPage).Skip((page - 1) * perPage),
                total,
                page,
                last_page = total / perPage
            };
        

           // return query;
        }


    }
}
