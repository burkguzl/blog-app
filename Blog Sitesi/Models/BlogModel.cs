using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Sitesi.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Resim { get; set; }
        public string Yazar { get; set; }
        public DateTime Tarih { get; set; }
        public bool Anasayfa { get; set; }
        public bool Onay { get; set; }
        public int KategoriId { get; set; }

    }
}