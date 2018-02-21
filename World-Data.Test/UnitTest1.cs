using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using World_Data.Models;

namespace World_Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            WorldData.GetAll();
            //Act
            List<Country> testCountryList = new List<Country>
            {
                new Country("","Aruba"),
                new Country("","Afghanistan"),
                new Country("","Angola"),
                new Country("","Anguilla"),
                new Country("","Albania"),
                new Country("","Andorra"),
                new Country("","Netherlands Antilles"),
                new Country("","United Arab Emirates"),
                new Country("","Argentina"),
                new Country("","Armenia"),
                new Country("","American Samoa"),
                new Country("","Antarctica"),
                new Country("","French Southern territories"),
                new Country("","Antigua and Barbuda"),
                new Country("","Australia"),
                new Country("","Austria"),
                new Country("","Azerbaijan"),
                new Country("","Burundi"),
                new Country("","Belgium"),
                new Country("","Benin"),
                new Country("","Burkina Faso"),
                new Country("","Bangladesh"),
                new Country("","Bulgaria"),
                new Country("","Bahrain"),
                new Country("","Bahamas"),
                new Country("","Bosnia and Herzegovina"),
                new Country("","Belarus"),
                new Country("","Belize"),
                new Country("","Bermuda"),
                new Country("","Bolivia")
            };
            List<Country> countryList = WorldData.CountryList;
            //Assert
            for(int i = 0; i < 30; i++)
            {
                Assert.AreEqual(WorldData.CountryList[i].CountryName, testCountryList[i].CountryName);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            WorldData.GetAll();
            //Act
            List<City> testCityList = new List<City>{new City(),new City("","Qandahar")};
            List<City> cityList = WorldData.CityList;
            Assert.AreEqual(WorldData.CityList[1].CityName, testCityList[1].CityName);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            WorldData.GetAll();
            WorldData.PopulateLists();
            //Act
            List<City> thisCountryCities = WorldData.CountryList[0].GetCityList();
            Console.WriteLine(thisCountryCities[0].CityName);
            //Assert
            Assert.AreEqual(thisCountryCities[0].CityName, "Oranjestad");
        }
    }
}
