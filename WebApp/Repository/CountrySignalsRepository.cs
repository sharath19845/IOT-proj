using Data.Models.DB;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CountrySignalsRepository: ICountrySignalsRepository
    {
        private readonly IOTContext _iotContext;

        public CountrySignalsRepository(IOTContext iotContext)
        {
            _iotContext = iotContext;
        }
        public List<CountrySignals> GetData()
        {
            List<CountrySignals> pallets = _iotContext.CountrySignals.Select(t => t).ToList();
            return pallets;
        }
    }
}
