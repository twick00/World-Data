namespace World_Data.Models
{
    public class City //countryCode, cityName, cityDistrict, cityPopulation
    {
        public City(string countryCode = "", string cityName = "", string cityDistrict = "", long cityPopulation = 0)
        {
            _cityName = cityName;
            _countryCode = countryCode;
            _cityDistrict = cityDistrict;
            _cityPopulation = cityPopulation;
        }
        private string _cityName;
        private string _countryCode;
        private string _cityDistrict;
        private long _cityPopulation;


        public string CityName { get => _cityName; set => _cityName = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public string CityDistrict { get => _cityDistrict; set => _cityDistrict = value; }
        public long CityPopulation { get => _cityPopulation; set => _cityPopulation = value; }
    }
}
