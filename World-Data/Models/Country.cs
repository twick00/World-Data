using System.Collections.Generic;
using System;

namespace World_Data.Models
{
public class Country //countryCode, countryName, countryRegion, double-surfaceArea
        {
            private List<City> ThisCountryCity = new List<City>{};
            private List<Language> ThisCountryLanguage = new List<Language>{};
            public List<City> GetCityList()
            {
                return ThisCountryCity;
            }
            public List<Language> GetLangList()
            {
                return ThisCountryLanguage;
            }
            public void SetCityList(List<City> newCityList)
            {
                ThisCountryCity = newCityList;
            }
            public void SetLangList(List<Language> newLangList)
            {
                ThisCountryLanguage = newLangList;
            }
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