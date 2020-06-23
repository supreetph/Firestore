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

namespace FirestoreDemo.Controllers
{
    public class PeopleController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "",
            BasePath = "https://hip-voyager-241415.firebaseio.com"
            

        };
        IFirebaseClient client;
        public IActionResult Index()
        {
            return View();
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
