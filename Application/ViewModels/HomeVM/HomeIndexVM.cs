using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels.HomeVM
{
    /// <summary>
    /// klasa pomocnicza (DTO) do przeszyłania dużęj ilośći danych 
    /// </summary>
    public class HomeIndexVM
    {
        public List<Book> FirstSlider { get; set; }
        public List<Book> Promotions { get; set; }
        public List<Book> NewBooks { get; set; }

        
    }
}
