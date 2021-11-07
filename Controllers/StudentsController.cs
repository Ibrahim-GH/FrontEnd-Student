using FB1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FB1.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students

        public ActionResult Index()
        {
            WebRequest w = WebRequest.Create("http://localhost:62696/api/Student/GetAllStudents");

            Stream s = w.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(s);

            string students = reader.ReadToEnd();

            ViewBag.Students = JsonConvert.DeserializeObject<Student[]>(students);

            return View();
        }


        public ActionResult Create()
        {
           
            return View();
        }

        public ActionResult Add(string name , int Age)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();

                values["Name"] = name;
                values["Age"] = Age.ToString();

                var respons = client.UploadValues("http://localhost:62696/api/Student/CreateStudent", "POST" , values);

                var result = Encoding.Default.GetString(respons);
            }

                return RedirectToAction("Index");
        }



      

        public ActionResult Edit(int Id)
        {
            WebRequest w = WebRequest.Create("http://localhost:62696/api/Student/GetStudentById/"+ Id);

            Stream s = w.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(s);

            string student = reader.ReadToEnd();

            ViewBag.Students = JsonConvert.DeserializeObject<Student>(student);

            return View();
        }


        public ActionResult Update(int id , string name, int Age)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();

                values["Id"] = id.ToString();
                values["Name"] = name;
                values["Age"] = Age.ToString();

                var respons = client.UploadValues("http://localhost:62696/api/Student/UpdateStudent", "POST", values);

                var result = Encoding.Default.GetString(respons);
            }

            return View();
        }



        public ActionResult Details(int Id)
        {
            WebRequest w = WebRequest.Create("http://localhost:62696/api/Student/GetStudentById/"+ Id);

            Stream s = w.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(s);

            string student = reader.ReadToEnd();

            ViewBag.Student = JsonConvert.DeserializeObject<Student>(student);

            return View();
        }

        public ActionResult Delete(int Id)
        {
            WebRequest w = WebRequest.Create("http://localhost:62696/api/Student/DeleteStudent/"+ Id);

            Stream s = w.GetResponse().GetResponseStream();

            return RedirectToAction("Index");
        }















        /*
   public ActionResult Index()
    {
        WebRequest w = WebRequest.Create("http://localhost:62696/api/Students/GetAllStudents");

        Stream str = w.GetResponse().GetResponseStream();

        StreamReader r = new StreamReader(str);

        string students = r.ReadToEnd();

        ViewBag.Students = JsonConvert.DeserializeObject<Student[]>(students);
        return View();
    }


    public ActionResult Create()
    {
        return View();
    }


    public ActionResult Add(string name, int age)
    {
        using (WebClient client = new WebClient())
        {
            var values = new NameValueCollection();
            values["Name"] = name;
            values["Age"] = age.ToString();


            var respons = client.UploadValues("http://localhost:62696/api/Students/CreateStudent", "POST",values);
            var resault = Encoding.Default.GetString(respons);
        }


            return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        WebRequest w = WebRequest.Create("http://localhost:62696/api/Students/GetStudentById/"+id);

       // w.Method = "POST";

        Stream str = w.GetResponse().GetResponseStream();

        StreamReader r = new StreamReader(str);

        string student = r.ReadToEnd();

        ViewBag.Student = JsonConvert.DeserializeObject<Student>(student);
        return View();
    }

    public ActionResult Update(int Id , string Name, int Age)
    {
        using (var client = new WebClient())
        {
            var values = new NameValueCollection();

            values["Id"] = Id.ToString();
            values["Name"] = Name;
            values["Age"] = Age.ToString();


            var respons = client.UploadValues("http://localhost:62696/api/Students/UpdateStudent/", "PUT", values);
            var resault = Encoding.Default.GetString(respons);
        }

        return RedirectToAction("Index");
    }


    public ActionResult Details(int id)
    {
        WebRequest w = WebRequest.Create("http://localhost:62696/api/Students/GetStudentById/" + id);

        // w.Method = "POST";

        Stream str = w.GetResponse().GetResponseStream();

        StreamReader r = new StreamReader(str);

        string student = r.ReadToEnd();

        ViewBag.Student = JsonConvert.DeserializeObject<Student>(student);
        return View();
    }


    public ActionResult Delete(int id)
    {
        WebRequest w = WebRequest.Create("http://localhost:62696/api/Students/DeleteStudent/" + id);

        //w.Method = "DELETE";

        Stream str = w.GetResponse().GetResponseStream();


        return RedirectToAction("Index");
    }
    */

    }
}





