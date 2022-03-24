using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureWebAPIPraticalTest2.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Countrycode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetails> CountryDetails { get; set; }
    }



    public class CountryDetails
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }

        public int CountryId { get; set; }
      //  public Country Country { get; set; }
    }
}
