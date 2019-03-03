using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog_Sitesi.Models
{
    public class BlogContext:DbContext
    {
        
        public BlogContext():base("blogConnection")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Blog> Bloglar { get; set; }
    }
}