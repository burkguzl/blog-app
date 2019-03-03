using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Sitesi.Models
{
    public class KategoriModel
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public int BlogSayisi { get; set; }
    }
}