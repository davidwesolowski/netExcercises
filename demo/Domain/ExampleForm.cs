using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace demo.Domain
{
    [Bind("Name, Surname, Description, Country")]
    public class ExampleForm
    {
        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Kraj")]
        public string  Country { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(Description)}: {Description}, {nameof(Country)}: {Country}";
        }
    }
}