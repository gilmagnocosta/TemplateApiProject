using TemplateApiProject.Application.ViewModel.Base;

namespace TemplateApiProject.Application.Responses
{
    public class AddressResponse
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
