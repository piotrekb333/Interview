using InterviewLists.Application.Models.WebServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Interfaces.WebServices
{
    public interface ICountriesWebService
    {
        IEnumerable<CountriesModel> GetCountries();
    }
}
