using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.HomeVM
{
    public class HomeIndexVM
    {
        public List<Book> FirstSlider { get; set; }
        public List<Book> Promotions { get; set; }
        public List<Book> Books { get; set; }

        
    }
}
