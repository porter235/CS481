using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace CS481.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            HttpClient client = new HttpClient();
            var response1 = client.GetAsync("http://api.openweathermap.org/data/2.5/weather?zip=25701,us&appid=1e20f88620ba23d247b915ee5da84e67").Result;
            var data1 = response1.Content.ReadAsStringAsync();
            var rawWeather = JsonConvert.DeserializeObject(data1.Result);

            System.Diagnostics.Debug.WriteLine(rawWeather);
            ViewBag.result = rawWeather;
            int temp = (ViewBag.result.main.temp - 273) * (9 / 5) + 32;
            System.Diagnostics.Debug.WriteLine(temp);
            ViewBag.temp = temp;
            

            var response2 = client.GetAsync("https://api.solunar.org/solunar/38.4192,82.4452," + DateTime.Now.ToString("yyyyMMdd") + ",6").Result;
            var data2 = response2.Content.ReadAsStringAsync();
            var rawMoon = JsonConvert.DeserializeObject(data2.Result);
            System.Diagnostics.Debug.WriteLine(rawMoon);
            ViewBag.moon = rawMoon;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}