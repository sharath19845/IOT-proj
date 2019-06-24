using Data.Models.DB;
using RepositoryInterfaces;
using ServiceInterfaces;
using System.Collections.Generic;

namespace Services
{
    public class GetSignals : IGetSignals
    {
        private ICountrySignalsRepository _countrySignalsRepository { get; set; }

        public GetSignals(ICountrySignalsRepository countrySignalsRepository)
        {
            _countrySignalsRepository = countrySignalsRepository;
        }

        public List<CountrySignals> GetData()
        {
            List<CountrySignals> countrySignals = _countrySignalsRepository.GetData();
            return countrySignals;
        }
    }
}
