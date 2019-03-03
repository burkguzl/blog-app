using Blog_Sitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Blog_Sitesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private BlogContext context = new BlogContext();

        
        public ActionResult Index()
        {

            var bloglar = context.Bloglar.Where(i => i.Onay == true && i.Anasayfa == true)
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Tarih = i.Tarih,
                    Resim = i.Resim,
                    Yazar = i.Yazar,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay

                });
 
            return View(bloglar.ToList());
        }
    }
}