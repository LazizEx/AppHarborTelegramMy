using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEMP1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        ////[HttpPost]
        //public ActionResult Index(string msg)
        //{
        //    //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureJobsStorage"].ConnectionString);
        //    //CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
        //    //CloudQueue queue = queueClient.GetQueueReference("inputqueue");
        //    //queue.CreateIfNotExists();
        //    //queue.AddMessage(new CloudQueueMessage(msg));

        //    return View();
        //}

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