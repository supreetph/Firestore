using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FirestoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirestoreDemo.Controllers
{
    public class PeopleController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RuACwgmFjFnMGMGvLPNbqAwhJkZRmI9DTZqrkaE7",
            BasePath = "https://hip-voyager-241415.firebaseio.com"
            

        };
        IFirebaseClient client;
        public IActionResult Index()
        {
            client = new FirebaseClient(config);
            var response = client.Get("People");
            dynamic jResult = JsonConvert.DeserializeObject(response.Body);
            var list = new List<People>();
            foreach (var item in jResult)
            {
                list.Add(JsonConvert.DeserializeObject<People>(((JProperty)item).Value.ToString()));

            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Create(People people)
        {
            InsertData(people);
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        

        private void InsertData(People people)
        {
            client = new FirebaseClient(config);
            _ = client.Push("People/", people);
        }
    }
}
