using MCC69APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCC69APP.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        string Baseurl = "https://localhost:5001/api/";
        public AccountController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                string token = null;
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", "Your Oauth token");
                   
                    //test
                    client.BaseAddress = new Uri(Baseurl + "Account/Login");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<User>("Login", user);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        // Get the response
                        var ResultJsonString = result.Content.ReadAsStringAsync();
                        ResultJsonString.Wait();
                        JObject rss = JObject.Parse(ResultJsonString.Result);

                        token = rss.SelectToken("token").Value<string>();

                        var tokenHandler = new JwtSecurityTokenHandler();
                        JwtSecurityToken DecodeToken = tokenHandler.ReadJwtToken(token);
                        var NameToken=DecodeToken.Claims.FirstOrDefault(claim => claim.Type.Equals("unique_name")).Value;
                        var RoleToken = DecodeToken.Claims.FirstOrDefault(claim => claim.Type.Equals("role")).Value;
                        var ExpToken = DecodeToken.Claims.FirstOrDefault(claim => claim.Type.Equals("exp")).Value;
                        HttpContext.Session.SetString("Token", token.ToString());
                        HttpContext.Session.SetString("Name", NameToken.ToString());
                        HttpContext.Session.SetString("Role", RoleToken.ToString());
                        HttpContext.Session.SetString("Exp", ExpToken.ToString());
                    }
                    
                }
                //HttpContext.Session.SetString("username", user.UserName);
                
                //HttpContext.Session.Get("username");
                return View("Success");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }


    }
}
