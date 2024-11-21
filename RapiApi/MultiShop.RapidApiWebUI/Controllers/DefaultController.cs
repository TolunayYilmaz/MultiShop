using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/ankara/EN"),
                Headers =
    {
        { "x-rapidapi-key", "f1ff663788mshb3e1dc4de29172cp1bc44cjsnc58b1cfa061c" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);

                return View("index", value);
            }


        }

        public async Task<IActionResult> Exchange()
        {
          
            List<ExchangeViewModel.Rootobject> exchangeList = new List<ExchangeViewModel.Rootobject>();   
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=usd&to_symbol=Try&language=tr"),
                Headers =
    {
        { "x-rapidapi-key", "f1ff663788mshb3e1dc4de29172cp1bc44cjsnc58b1cfa061c" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                exchangeList.Add(value);

            }



            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=eur&to_symbol=Try&language=tr"),
                Headers =
    {
        { "x-rapidapi-key", "f1ff663788mshb3e1dc4de29172cp1bc44cjsnc58b1cfa061c" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client2.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                exchangeList.Add(value);

            }

            return View(exchangeList);
          
        }
    }
}
