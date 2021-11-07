using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FB1.Models;

namespace FB1.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files

        public ActionResult Index(int Id)
        {
            WebRequest w = WebRequest.Create("http://localhost:62696/api/File/GetAllFiles/"+ Id);

            Stream s = w.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(s);

            string files = reader.ReadToEnd();

            ViewBag.Files = JsonConvert.DeserializeObject<Models.File[]>(files);
            ViewBag.StudentId = Id;

            return View();
        }



        public ActionResult Create(int Id)
        {
            ViewBag.StudentId = Id;
            return View();
        }

        public ActionResult Delete(int Id , int StudentId)
        {
            WebRequest w = WebRequest.Create("http://localhost:62696/api/File/DeleteFile/" + Id);

            Stream s = w.GetResponse().GetResponseStream();

            return RedirectToAction("Index", new { Id = StudentId });
        }











        /*
    public ActionResult Index(int id)
    {
        WebRequest w = WebRequest.Create("http://localhost:62696/api/Files/GetAllFiles/" + id);

        Stream str = w.GetResponse().GetResponseStream();

        StreamReader r = new StreamReader(str);

        string files = r.ReadToEnd();

        ViewBag.files = JsonConvert.DeserializeObject<Models.File[]>(files);
        ViewBag.StudentId = id;
        return View();
    }

    public ActionResult Create(int id)
    {
        ViewBag.StudentId = id;
        return View();
    }


    public ActionResult Delete(int Id, int StudentId)
    {
        WebRequest wrq = WebRequest.Create("http://localhost:62696/api/Files/DeleteFile/" + Id);
        wrq.Method = "DELETE";

        Stream stream = wrq.GetResponse().GetResponseStream();

        return RedirectToAction("Index", new { Id = StudentId });
    }
    */

    }
}