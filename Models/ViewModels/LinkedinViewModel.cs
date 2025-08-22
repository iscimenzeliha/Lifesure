using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje7MVC.Models.ViewModels
{
    public class LinkedinViewModel
    {
        // LinkedIn şirket takipçi sayısı
        //public int LinkedInFollowers { get; set; }

        // İsteğe bağlı: Platform isimlerini veya URL'lerini tutmak için
        // public string LinkedInUrl { get; set; }
        public int follower_count { get; set; }
    }
}