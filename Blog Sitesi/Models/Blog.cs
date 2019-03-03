using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Sitesi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public string Resim { get; set; }
        public string Yazar { get; set; }
        public DateTime Tarih { get; set; }
        public bool Anasayfa { get; set; }
        public bool Onay { get; set; }

        //Tanımlama yaparken Id den önce yazılacak isim Kategori modelinin ismiyle aynı olmalı!
        //buraya yazacağımız numara aynı zamanda kategori modelin içindeki id ile eşleşecek ve blogun kategorisi belirlenecek.
        public int KategoriId { get; set; }

        //Blog nesneni içinden kategori modeline ulaşmak için bir yol oluşturduk.(tabloda gözükmeyecek)
        //Her blog 1 kategoriye bağlı olacağından liste tipinde yapmadık.
        public Kategori Kategori { get; set; }

    }
}