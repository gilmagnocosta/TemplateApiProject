using TemplateApiProject.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApiProject.Domain.Entity.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public Address() { }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street.ToUpper();
            yield return Number.ToUpper();
            yield return Neighborhood.ToUpper();
            yield return City.ToUpper();
            yield return State.ToUpper();
            yield return ZipCode.ToUpper();
            yield return Country.ToUpper();
        }
    }
}
