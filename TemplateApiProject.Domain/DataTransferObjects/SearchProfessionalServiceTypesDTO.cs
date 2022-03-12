using System;

namespace TemplateApiProject.Domain.DataTransferObjects
{
    public class SearchProfessionalServiceTypesDTO
    {
        public Guid? ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ProfessionalName { get; set; }

    }
}
