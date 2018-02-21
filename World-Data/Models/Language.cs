namespace World_Data.Models
{
     public class Language // countryCode, countryLang, bool-boolOfficialLanguage, double-percentageSpeaks
        {
            public Language(string countryCode, string countryLang, bool boolOfficialLanguage, double percentageSpeaks)
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
}