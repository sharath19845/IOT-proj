using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceInterfaces;
using System.Linq;

namespace UI.Controllers
{
    public class ScanningAppController : Controller
    {
        private IGetSignals _getSignals { get; set; }
        public ScanningAppController(IGetSignals getSignals)
        {
            _getSignals = getSignals;
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult GetSignals()
        {
            var signalsData = _getSignals.GetData();
            string json =

                JsonConvert.SerializeObject(signalsData.Select(s => new
                {
                    country = s.Country,
                    signalStrength = s.SignalStrength
                }));

            return Ok(json);
        }
    }
}