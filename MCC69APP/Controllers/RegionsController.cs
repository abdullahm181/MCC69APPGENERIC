using MCC69APP.Context;
using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace MCC69APP.Controllers
{
    public class RegionsController : Controller
    {
        HttpAPi<Regions> httpAPI;
        public RegionsController()
        {
            this.httpAPI = new HttpAPi<Regions>("Regions");
        }
        // GET ALL
        
        public IActionResult Index()
        {
            IEnumerable<Regions> regions = null;
            regions = httpAPI.Get();

            if (regions == Enumerable.Empty<Regions>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(regions);

        }
        // GET By ID

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Regions regions = null;
            regions = httpAPI.Get(id);
            if (regions == null) {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            
            return View(regions);


        }
        // PUT
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Regions regions = null;
            regions = httpAPI.Get(id);
            if (regions == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(regions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Regions regions)
        {
            string result = httpAPI.Edit(regions);
            if (!string.IsNullOrWhiteSpace(result)&& result=="200") {
                return RedirectToAction(nameof(Index));
            }
            return View(regions);
        }
        // POST
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Regions regions)
        {
            string result = httpAPI.Create(regions);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(regions);
        }
        

        //DELETE
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Regions regions = null;
            regions = httpAPI.Get(id);
            if (regions == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(regions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Regions regions)
        {
            string result = httpAPI.Delete(regions);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(regions);
        }


        /*// GET ALL
        string Baseurl = "https://localhost:5001/api/";
        public IActionResult Index()
        {
            IEnumerable<Regions> regions = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("Regions");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // Get the response
                    var ResultJsonString = result.Content.ReadAsStringAsync();
                    ResultJsonString.Wait();
                    JObject rss = JObject.Parse(ResultJsonString.Result);
                    JArray data = (JArray)rss["data"];
                    regions = JsonConvert.DeserializeObject<List<Regions>>(JsonConvert.SerializeObject(data));
                    //RootObject<Regions> ro = JsonConvert.DeserializeObject<RootObject<Regions>>(ResultJsonString.Result);
                    // regions = ro.Data;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    regions = Enumerable.Empty<Regions>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(regions);

        }
        // GET By ID

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Regions regions = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("Regions/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // Get the response
                    var ResultJsonString = result.Content.ReadAsStringAsync();
                    ResultJsonString.Wait();
                    JObject rss = JObject.Parse(ResultJsonString.Result);
                    JObject data = (JObject)rss["data"];
                    regions = JsonConvert.DeserializeObject<Regions>(JsonConvert.SerializeObject(data));
                }
                else //web api sent error response 
                {

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(regions);


        }

        public IActionResult Edit(int id)
        {
            Regions regions = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("Regions/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // Get the response
                    var ResultJsonString = result.Content.ReadAsStringAsync();
                    ResultJsonString.Wait();
                    JObject rss = JObject.Parse(ResultJsonString.Result);
                    JObject data = (JObject)rss["data"];
                    regions = JsonConvert.DeserializeObject<Regions>(JsonConvert.SerializeObject(data));
                }
                else //web api sent error response 
                {

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(regions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Regions regions)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "Regions/" + regions.Id.ToString());

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Regions>(client.BaseAddress, regions);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(regions);
        }
        // POST
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Regions regions)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "Regions");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Regions>("Regions", regions);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(regions);
        }
        // PUT
        // DELETE
        //DELETE
        public IActionResult Delete(int id)
        {
            Regions regions = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("Regions/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // Get the response
                    var ResultJsonString = result.Content.ReadAsStringAsync();
                    ResultJsonString.Wait();
                    JObject rss = JObject.Parse(ResultJsonString.Result);
                    JObject data = (JObject)rss["data"];
                    regions = JsonConvert.DeserializeObject<Regions>(JsonConvert.SerializeObject(data));
                }
                else //web api sent error response 
                {

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(regions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Regions regions)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Regions/" + regions.Id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));
        }*/


    }
}
