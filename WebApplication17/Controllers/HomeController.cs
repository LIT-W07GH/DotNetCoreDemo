using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication17.Models;

namespace WebApplication17.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Counter()
        {
            //int counter = 0;
            //string counterString = HttpContext.Session.GetString("counter");
            //if (counterString != null)
            //{
            //    counter = int.Parse(counterString);
            //}

            //HttpContext.Session.SetString("counter", $"{counter + 1}");
            //var vm = new CounterViewModel
            //{
            //    Count = counter
            //};
            //return View(vm);
            CounterViewModel vm = HttpContext.Session.Get<CounterViewModel>("counter");
            if (vm == null)
            {
                vm = new CounterViewModel
                {
                    Count = 0
                };
            }

            vm.Count++;
            HttpContext.Session.Set("counter", vm);
            return View(vm);
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
