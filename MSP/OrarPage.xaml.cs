using System;
using Windows.UI.Xaml;

namespace MSP
{
    public sealed partial class OrarPage
    {
        public OrarPage()
        {
            this.InitializeComponent();

            var dayOfWeek = DateTime.Now.DayOfWeek;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: orarLuni.Width = 200; orarLuni.BorderThickness = new Thickness(1); break;
                case DayOfWeek.Tuesday: orarMarti.Width = 200; orarMarti.BorderThickness = new Thickness(1); break;
                case DayOfWeek.Wednesday: orarMiercuri.Width = 200; orarMiercuri.BorderThickness = new Thickness(1); break;
                case DayOfWeek.Thursday: orarJoi.Width = 200; orarJoi.BorderThickness = new Thickness(1); break;
                case DayOfWeek.Friday: orarVineri.Width = 200; orarVineri.BorderThickness = new Thickness(1); break;
                case DayOfWeek.Saturday: orarSambata.Width = 200; orarSambata.BorderThickness = new Thickness(1); break;
                case DayOfWeek.Sunday: orarDuminica.Width = 200; orarDuminica.BorderThickness = new Thickness(1); break;
            }
        }
    }
}
