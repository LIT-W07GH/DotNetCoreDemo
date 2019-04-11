using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUpload.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication17.Controllers
{

    #region interface review
    //public interface IMyInterface
    //{
    //    void Foo();
    //}

    //public class Something : IMyInterface
    //{
    //    public void Foo()
    //    {

    //    }
    //}

    //public class MyClass
    //{
    //    public MyClass(IMyInterface my)
    //    {
    //        my.Foo();
    //    }
    //}

    //public class Program2
    //{
    //    public static void FakeMain()
    //    {
    //        MyClass mc = new MyClass(new Something());
    //    }
    //}
    #endregion

    public class FileUploadController : Controller
    {
        private IHostingEnvironment _environment;
        private string _connectionString;

        public FileUploadController(IHostingEnvironment environment,
            IConfiguration configuration)
        {
            _environment = environment;
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload(IFormFile myFile)
        {
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(myFile.FileName)}";
            string fullPath = Path.Combine(_environment.WebRootPath, "uploads", fileName);
            using (FileStream stream = new FileStream(fullPath, FileMode.CreateNew))
            {
                myFile.CopyTo(stream);
            }

            var mgr = new ImageManager(_connectionString);
            mgr.SaveImage(new Image
            {
                FileName = fileName,
                Description = "from .net core"
            });


            return RedirectToAction("Index");
        }
    }
}