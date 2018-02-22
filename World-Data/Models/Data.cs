using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World_Data;
using System;

namespace World_Data.Models
{
    public class WorldData
    {
        private static int color = 0;
        private static List<string> colArr = new List<string>{"#F44336","#E91E63","#9C27B0","#673AB7","#3F51B5","#2196F3","#03A9F4","#00BCD4","#009688","#4CAF50","#8BC34A","#CDDC39","#FFEB3B","#FFC107","#FF9800","#FF5722"};
        private static List<Country> CountryList = new List<Country>{};
        private static List<City> CityList = new List<City>{};
        private static List<Language> LangList = new List<Language>{};

        public static List<Country> GetCountryList()
        {
            return CountryList;
        }
        public static List<City> GetCityList()
        {
            return CityList;
        }
        public static List<Language> GetLangList()
        {
            return LangList;
        }
        public Country thisCountry;
        public List<City> ThisCountryCity = new List<City>{};
        public List<Language> ThisCountryLanguage = new List<Language>{};
        //...GETTERS AND SETTERS WILL GO HERE...
        public static void BuildCountry(string countryCode, string countryName, string countryRegion, string countryLocalName, string governmentForm = "N/A")
        {
            Country newCountry = new Country(countryCode, countryName, countryRegion);
            CountryList.Add(newCountry);
            PushCountryToDB(newCountry);
        }
        public static void PushCountryToDB(Country newCountry)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO country (Code, Name) VALUES (@CountryCode, @CountryName);";
            MySqlParameter code = new MySqlParameter("@CountryCode", newCountry.CountryCode);
            MySqlParameter country = new MySqlParameter("@CountryName", newCountry.CountryName);
            cmd.Parameters.Add(code);
            cmd.Parameters.Add(country);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static void DeleteCountry(string countryName)
        {
            foreach(var country in CountryList)
            {
                if(country.CountryName == countryName)
                {
                    string temp = country.CountryCode;
                    MySqlConnection conn = DB.Connection();
                    conn.Open();
                    var cmd = conn.CreateCommand() as MySqlCommand;
                    cmd.CommandText = @"DELETE FROM country WHERE Code = @CountryCode;";
                    MySqlParameter countryCode = new MySqlParameter("@CountryCode", country.CountryCode);
                    cmd.Parameters.Add(countryCode);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    if (conn != null)
                    {
                        conn.Dispose();
                    }
                }
            }
        }
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
        PopulateLists();
            }

        public static void PopulateLists()
        {
            foreach(var country in CountryList)
            {
                country.ThisCityList = GetCities(country.CountryCode);
                country.ThisLangList = GetLanguages(country.CountryCode);
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