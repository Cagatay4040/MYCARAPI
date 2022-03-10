using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYCAR.UI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MYCAR.UI.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Colors = ColorList();
            ViewBag.Transmissions = TransmissionList();
            ViewBag.Years = YearList();


            return View(new MyFilters());
        }

        //[HttpPost]
        //public IActionResult Index(MyFilters filters)
        //{
        //    ViewBag.Colors = ColorList();
        //    ViewBag.Transmissions = TransmissionList();
        //    ViewBag.Years = YearList();

        //    string url = "http://127.0.0.1:5000/cars/list";

        //    if (filters.Color != null)
        //    {
        //        url = $"{url}?extcolor={filters.Color}";
        //    }

        //    if (filters.Brand != null)
        //    {
        //        url = $"{url}?brand={filters.Brand}";
        //    }

        //    if (filters.Transmission != null)
        //    {
        //        url = $"{url}?trans={filters.Transmission}";
        //    }

        //    if (filters.Year != null)
        //    {
        //        url = $"{url}?year={filters.Year}";
        //    }


        //    return View("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> Index(MyFilters filters)
        {
            ViewBag.Colors = ColorList();
            ViewBag.Transmissions = TransmissionList();
            ViewBag.Years = YearList();

            string url = "http://127.0.0.1:5000/cars/list";

            if (filters.Color != null)
            {
                url = $"{url}?extcolor={filters.Color}";
            }

            if (filters.Brand != null)
            {
                url = $"{url}?brand={filters.Brand}";
            }

            if (filters.Transmission != null)
            {
                url = $"{url}?trans={filters.Transmission}";
            }

            if (filters.Year != null)
            {
                url = $"{url}?year={filters.Year}";
            }

            HttpResponseMessage response;
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(600);

            string responseBody;

            client.BaseAddress = new Uri("http://127.0.0.1:5000");
            response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();

            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(responseBody);

            ViewBag.Cars = cars;

            return View("Index");
        }

        private List<string> ColorList()
        {
            List<string> colors = new List<string>();

            colors.Add("Beige");
            colors.Add("Black");
            colors.Add("Blue");
            colors.Add("Brown");
            colors.Add("Gold");
            colors.Add("Gray");
            colors.Add("Green");
            colors.Add("Orange");
            colors.Add("Purple");
            colors.Add("Red");
            colors.Add("Silver");
            colors.Add("White");
            colors.Add("Yellow");

            return colors;
        }

        private List<string> TransmissionList()
        {
            List<string> transmissions = new List<string>();

            transmissions.Add("Automanual");
            transmissions.Add("Automatic");
            transmissions.Add("CVT");
            transmissions.Add("Manual");
            transmissions.Add("Unknown");

            return transmissions;
        }

        private List<string> YearList()
        {
            List<string> years = new List<string>();

            for (int i = DateTime.Now.Year; i > 1940; i--)
            {
                years.Add(i.ToString());
            }

            return years;
        }
    }
}
