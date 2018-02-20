using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World_Data;
using System;

namespace World_Data.Models
{
    public class WorldData
    {
        private static Dictionary<string,WorldData> WorldDict = new Dictionary<string, WorldData>{};
        public class Country
        {
            public Country(string countryCode, string countryName, string countryRegion, float surfaceArea)
            {
                _countryCode = countryCode;
                _countryName = countryName;
                _countryRegion = countryRegion;
                _surfaceArea = surfaceArea;
            }
            private string _countryCode;
            private string _countryName;
            private string _countryRegion;
            private float _surfaceArea;

            public string CountryCode { get => _countryCode; set => _countryCode = value; }
            public string CountryName { get => _countryName; set => _countryName = value; }
            public string CountryRegion { get => _countryRegion; set => _countryRegion = value; }
            public float SurfaceArea { get => _surfaceArea; set => _surfaceArea = value; }
        }
        public class City
        {
            public City(string countryCode, string cityName, string cityDistrict, int cityPopulation)
            {
                _cityName = cityName;
                _countryCode = countryCode;
                _cityDistrict = cityDistrict;
                _cityPopulation = cityPopulation;
            }
            private string _cityName;
            private string _countryCode;
            private string _cityDistrict;
            private int _cityPopulation;

            public string CityName { get => _cityName; set => _cityName = value; }
            public string CountryCode { get => _countryCode; set => _countryCode = value; }
            public string CityDistrict { get => _cityDistrict; set => _cityDistrict = value; }
            public int CityPopulation { get => _cityPopulation; set => _cityPopulation = value; }
        }
        public class CountryLanguage
        {
            public CountryLanguage(string countryCode, string countryLang, bool boolOfficialLanguage, double percentageSpeaks)
            {
                _countryCode = countryCode;
                _countryLang = countryLang;
                _boolOfficialLanguage = boolOfficialLanguage;
                _percentageSpeaks = percentageSpeaks;
            }
            private string _countryCode;
            private string _countryLang;
            private bool _boolOfficialLanguage;
            private double _percentageSpeaks;

            public string CountryCode { get => _countryCode; set => _countryCode = value; }
            public string CountryLang { get => _countryLang; set => _countryLang = value; }
            public bool BoolOfficialLanguage { get => _boolOfficialLanguage; set => _boolOfficialLanguage = value; }
            public double PercentageSpeaks { get => _percentageSpeaks; set => _percentageSpeaks = value; }
        }
        private Country _country;
        private List<City> _city;
        private List<CountryLanguage> _countryLanguages;

        public WorldData(string Description, int Id = 0)
        {

        }
        //...GETTERS AND SETTERS WILL GO HERE...
        public static Dictionary<string,WorldData> GetAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            WorldDict.Clear();
            while(rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryRegion = rdr.GetString(3);
                float surfaceArea = rdr.GetFloat(4);
                Country newCountry = new Country{countryCode,countryName,countryRegion,surfaceArea};
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return WorldDict;
        }

        public List<City> GetCities(string code)
        {
            List<City> thisCodeCities = new List<City>{};
            foreach(var city in _city)
            {
                if (city.CountryCode == code)
                {
                    thisCodeCities.Add(city);
                }
            }
            return thisCodeCities;
        }
        public List<CountryLanguage> GetLanguages(string code)
        {
            List<CountryLanguage> thisCodeLangs = new List<CountryLanguage>{};
            foreach(var language in _countryLanguages)
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