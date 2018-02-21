using System.Collections.Generic;
using System;

namespace World_Data.Models
{
public class Country //countryCode, countryName, countryRegion, double-surfaceArea
        {
            private List<City> ThisCountryCity = new List<City>{};
            private List<Language> ThisCountryLanguage = new List<Language>{};
            public Language GetPrimaryLanguage()
            {
                foreach(var lang in ThisCountryLanguage)
                {   
                    if (lang.BoolOfficialLanguage == true)
                    {

                        return lang;
                    }
                }      
                return null;     
            }

        public List<Language> ThisLangList { get => ThisCountryLanguage; set => ThisCountryLanguage = value; }
        public List<City> ThisCityList { get => ThisCountryCity; set => ThisCountryCity = value; }
            public Country(string countryCode = "", string countryName = "", string countryRegion = "", double surfaceArea = 0.00)
            {
                _countryCode = countryCode;
                _countryName = countryName;
                _countryRegion = countryRegion;
                _surfaceArea = surfaceArea;
            }
            private string _countryCode;
            private string _countryName;
            private string _countryRegion;
            private double _surfaceArea;

            public string CountryCode { get => _countryCode; set => _countryCode = value; }
            public string CountryName { get => _countryName; set => _countryName = value; }
            public string CountryRegion { get => _countryRegion; set => _countryRegion = value; }
            public double SurfaceArea { get => _surfaceArea; set => _surfaceArea = value; }

    }
}