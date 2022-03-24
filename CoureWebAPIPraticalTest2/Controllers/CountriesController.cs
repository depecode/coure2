using CoureWebAPIPraticalTest2.Data;
using CoureWebAPIPraticalTest2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoureWebAPIPraticalTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        //private readonly CountryDbContext _context;

        //public CountriesController(CountryDbContext context)
        //{
        //    _context = context;
        //}

        private readonly CountryRepository _repository;
        public CountriesController(CountryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_repository.All());
        }

        [HttpGet("search")]
        public IActionResult Search(
            [FromQuery(Name = "s")] string s,
            [FromQuery(Name = "sort")] string sort,
            [FromQuery(Name = "page")] int page
         )
        {
            return Ok(_repository.Query(s, sort, page));
        }

    }
}
