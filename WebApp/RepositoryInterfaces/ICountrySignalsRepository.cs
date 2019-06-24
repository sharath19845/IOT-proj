using Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryInterfaces
{
    public interface ICountrySignalsRepository
    {
        List<CountrySignals> GetData();
    }
}
