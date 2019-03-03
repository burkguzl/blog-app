using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Sitesi.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        //kategori nesnesi üzerinden bloglara erişmek için bir yol oluşturduk.(tabloda gözükmeyecek)
        //her bir kategori birden fazla bloga sahip olabileceğinden liste tipinden bir erişim sağladık.
        public List<Blog> Bloglar { get; set; }
    }   
}