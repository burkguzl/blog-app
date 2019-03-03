using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog_Sitesi.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
       
        protected override void Seed(BlogContext context)
        {

            List<Kategori> Kategoriler = new List<Kategori>()
            {
                new Kategori() { KategoriAdi="Bilim Teknoloji"},
                new Kategori() { KategoriAdi="Sağlık"},
                new Kategori() { KategoriAdi="Spor"},
                new Kategori() { KategoriAdi="Magazin"},
                new Kategori() { KategoriAdi="Tarih"},

            };

            foreach (var item in Kategoriler)
            {
                context.Kategoriler.Add(item);
            }

            context.SaveChanges();

            List<Blog> Bloglar = new List<Blog>()
            {
                new Blog() { Baslik="Bir Kalp Cerrahının Ev Yapımı Yaşam İksiri", İcerik="Yüksek tansiyon arteriyel kan damarlarına uygulanan yüksek basınç nedeniyle oluşan tıbbi bir durumdur. Herhangi bir belirti ve bulgu göstermez, ancak farkedilmez ve tedavi edilmezse kardiyovasküler sorunlarla sonuçlanabilir. Böbrek hastalığı, kalp krizi ve hatta görme yetersizliği olası problemlerdir. ", Resim="iksir.jpeg", Tarih=DateTime.Now.AddDays(-10), Yazar="Burak Güzel", KategoriId=2, Anasayfa=true,Onay=true  },
                new Blog() { Baslik="Diyet ve Egzersiz Olmadan Tığ Gibi Olun ", İcerik="Bundan 2 sene önceydi. Diyet yapmaya çalışırken bir mucizeye şahit oldum. Sizlerle bu olayı paylaşmak istedim. İnsanlar bazen hiç farkında olmadan çok faydalı bilgiler öğrenebiliyor. ", Resim="iksir.jpeg", Tarih=DateTime.Now.AddDays(-7), Yazar="Burak Güzel", KategoriId=3, Anasayfa=false,Onay=false  },
                new Blog() { Baslik="Sacco ve Vanzetti", İcerik="23 Ağustos 1927’de, İtalya doğumlu iki Amerikalı anarşist Nicolo Sacco ve Bartolomeo Vanzetti asılsız bir soygun suçlamasıyla 7 yıl yargılanıp, tüm dünyanın itirazlarına karşın elektrikli sandalyede idam edildiler. ", Resim="iksir.jpeg", Tarih=DateTime.Now.AddDays(-7), Yazar="Burak Güzel", KategoriId=5, Anasayfa=false,Onay=true  },
                new Blog() { Baslik="Din ve Bilim Arasındaki İlişkiyi Yeniden Tartışmak", İcerik="Modern dünyada Müslümanlar, İslam’ın insanlığın her sorununa çare sunduğunu düşünüyorlar. Bu inancın doğal sonucu olarak da Kuran’ın içinde her türlü bilgiyi barındırdığı düşünülüyor. ", Resim="iksir.jpeg", Tarih=DateTime.Now.AddDays(-2), Yazar="Burak Güzel", KategoriId=1, Anasayfa=true,Onay=true  },
                new Blog() { Baslik="Kapitalizm Bilimi Tahrip Ediyor", İcerik="Üniversite kapitalizmden önce de vardı ve kârın değil hakikat ve bilginin peşine düşerek kapitalist piyasanın buyruklarına boyun eğmeyi reddedebildiği zamanlar oldu. ", Resim="iksir.jpeg", Tarih=DateTime.Now, Yazar="Burak Güzel", KategoriId=1, Anasayfa=true,Onay=true  },

            };

            foreach (var item in Bloglar)
            {
                context.Bloglar.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}