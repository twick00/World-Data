using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World_Data;
using System;

namespace World_Data.Models
{
    public class WorldData
    {
        private static Dictionary<string,WorldData> WorldDict;

        public static List<Country> CountryList = new List<Country>{};
        public static List<City> CityList = new List<City>{};
        public static List<Language> LangList = new List<Language>{};

        public Country thisCountry;
        public List<City> ThisCountryCity = new List<City>{};
        public List<Language> ThisCountryLanguage = new List<Language>{};
        //...GETTERS AND SETTERS WILL GO HERE...
        public static void GetAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            CountryList.Clear();
            CityList.Clear();
            LangList.Clear();
            while(rdr.Read())
            {

                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryRegion = rdr.GetString(3);
                double surfaceArea = System.Convert.ToDouble(rdr.GetFloat(4));

                Country newCountry = new Country(countryCode, countryName, countryRegion, surfaceArea);

                CountryList.Add(newCountry);
            }
            conn.Close();
            conn.Open();
            cmd.CommandText = @"SELECT * FROM city;";
            rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string countryCode = rdr.GetString(2);
                string cityName = rdr.GetString(1);
                string cityDistrict = rdr.GetString(3);
                long cityPopulation = rdr.GetInt64(4);
                City newCity = new City(countryCode, cityName, cityDistrict, cityPopulation);
                CityList.Add(newCity);
            }
            conn.Close(); 
            conn.Open();
            cmd.CommandText = @"SELECT * FROM countrylanguage;";
            rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryLang = rdr.GetString(1);
                bool boolOfficialLanguage = (rdr.GetString(2) == "T") ? true : false;
                double percentageSpeaks = System.Convert.ToDouble(rdr.GetFloat(3));
                Language newLanguage = new Language(countryCode, countryLang, boolOfficialLanguage, percentageSpeaks);
                LangList.Add(newLanguage);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void PopulateLists()
        {
            foreach(var country in CountryList)
            {
                country.SetCityList(GetCities(country.CountryCode));
                country.SetLangList(GetLanguages(country.CountryCode));
            }
        }
        public static List<City> GetCities(string code)
        {   
            List<City> inCountryCities = new List<City>{};
            foreach(var city in CityList)
            {
                if (city.CountryCode == code)
                {
                    inCountryCities.Add(city);
                }
            }
            return inCountryCities;
        }

        public static List<Language> GetLanguages(string code)
        {
            List<Language> thisCodeLangs = new List<Language>{};
            foreach(var language in LangList)
            {
                if (language.CountryCode == code)
                {
                    thisCodeLangs.Add(language);
                }
            }
            return thisCodeLangs;
        }
    }
}