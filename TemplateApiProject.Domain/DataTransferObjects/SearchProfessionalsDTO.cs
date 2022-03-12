using System;

namespace TemplateApiProject.Domain.DataTransferObjects
{
    public class SearchProfessionalsDTO
    {
        public Guid? ServiceTypeId { get; set; }
        public string Name { get; set; }

    }
}
