using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje7MVC.Models.ViewModels
{
    public class FaqViewModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string QuestionPrompt { get; set; }
    }
}