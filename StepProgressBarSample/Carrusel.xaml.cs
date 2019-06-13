using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace StepProgressBarSample
{
    public partial class Carrusel : ContentPage
    {
        public List<Person> persons { get;    
        set; }

        public Carrusel()
        {
            try
            {
                InitializeComponent();

                persons = new List<Person>()
                {
                    new Person() { Name = "Corrado", ImageUri = "male.png" },
                    new Person() { Name = "Giulia", ImageUri = "female.png" },
                    new Person() { Name = "Corrado", ImageUri = "male.png" },
                    new Person() { Name = "Giulia", ImageUri = "female.png" },
                };
                this.BindingContext = this;

            }
            catch (Exception ex)
            {

            }
        }




        private void OnPositionSelected(object sender, SelectedPositionChangedEventArgs e)
        {
            Debug.WriteLine(e.SelectedPosition.ToString());
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }

    public class CarouselTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MaleTemplate { get; set; }

        public DataTemplate FemaleTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Person person = (Person)item;
            switch (person.ImageUri)
            {
                case "male.png":
                    return MaleTemplate;
                case "female.png":
                    return FemaleTemplate;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
