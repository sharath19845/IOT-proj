using Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceInterfaces
{
    public interface IGetSignals
    {
        List<CountrySignals> GetData();
    }
}
