using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.WebServices;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Infrastructure.WebServices
{
    public class CountriesWebService : ICountriesWebService
    {
        private readonly IRestClient _client;
        public CountriesWebService(IRestClient client)
        {
            _client = client;
            var uriBuilder = new UriBuilder("https://restcountries.eu/");
            _client.BaseUrl = uriBuilder.Uri;
        }

        public IEnumerable<CountriesModel> GetCountries()
        {
            var request = new RestRequest("rest/v2/all", Method.GET);
            var response = _client.Execute<List<CountriesModel>>(request);
            return response.Data;
        }
    }
}
