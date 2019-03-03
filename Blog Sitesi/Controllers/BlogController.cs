using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog_Sitesi.Models;

namespace Blog_Sitesi.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string q)
        {

            var bloglar = db.Bloglar.Where(i => i.Onay == true)
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Tarih = i.Tarih,
                    Resim = i.Resim,
                    Yazar = i.Yazar,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay,
                    KategoriId = i.KategoriId

                }).AsQueryable();
            //AsQueryable: bu sorgudan sonra yeni bir where sorgusu daha yapmamıza izin verir.
            if (q!=null)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(q));
            }

            if (id!=null)
            {
                bloglar = bloglar.Where(i => i.KategoriId == id);
            }

            return View(bloglar.ToList());
        }
        // GET: Blog
        public ActionResult Index()
        {
            //orderbydescending tarihe göre sondan başa sıralar.
            var bloglar = db.Bloglar.Include(b =>b.Kategori).OrderByDescending(i => i.Tarih);
            return View(bloglar.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            //KategoriId adında bir SelectList oluşturuyor. Daha sonra bu SelectList'in içine 
            //db.Kategoriler ile veritabanından Kategoriler listesini çekiyor. 
            //Bu SelectList de kullanıcı text olarak "KategoriAdi(yani kategorinin adını)" görüyor
            //Ama biz o kategori adının "Id" si ile işlem yapıyoruz.

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Baslik,İcerik,Resim,Yazar,KategoriId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.KategoriId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            //int parametresinin girilmesini istege baglı yapıyoruz. eğer girilmezse bunu kontrol edip hata gönderiyoruz.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //id de hata yoksa bulunan id yle eşleşen blog blog içine atılır ve sayfaya gönderilir.
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            //sayfada dropdown oldugu için kategoriler bilgisini gönderiyoruz.
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.Kategori);
            return View(blog);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,İcerik,Resim,Yazar,Anasayfa,Onay,KategoriId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var duzenlenmisblog = db.Bloglar.Find(blog.Id);
                if (duzenlenmisblog != null)
                {
                    duzenlenmisblog.Baslik = blog.Baslik;
                    duzenlenmisblog.Anasayfa = blog.Anasayfa;
                    duzenlenmisblog.KategoriId = blog.KategoriId;
                    duzenlenmisblog.Resim = blog.Resim;
                    duzenlenmisblog.Yazar = blog.Yazar;
                    duzenlenmisblog.İcerik = blog.İcerik;
                    duzenlenmisblog.Onay = blog.Onay;
                    db.SaveChanges();

                    //düzenlediğimiz blog bilgisini taşıyoruz.
                    TempData["Blog"] = duzenlenmisblog;

                    return RedirectToAction("Index");
                }
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.KategoriId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
