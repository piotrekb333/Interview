using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.WebServices;
using InterviewLists.Infrastructure.WebServices;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Xunit;

namespace InterviewLists.Application.Tests.WebServices
{
    public class CountriesWebServiceTests
    {
        private List<CountriesModel> models;
        public CountriesWebServiceTests()
        {

        }

        public void GetCountriesTest()
        {
            var mockFactory = new Mock<IRestClient>();
            IRestResponse response = new RestResponse();
            models = new List<CountriesModel> { new CountriesModel { Name = "test" }, new CountriesModel { Name = "test2" } };
            var json = JsonConvert.SerializeObject(models);
            response.Content = json;
            mockFactory.Setup(m => m.Execute(It.IsAny<IRestRequest>())).Returns(response);
            ICountriesWebService _countriesWebService = new CountriesWebService(mockFactory.Object);
            var result=_countriesWebService.GetCountries();

            Assert.True(result is IEnumerable<CountriesModel>);
            Assert.True(result.Count() > 0);
        }
    }
}
