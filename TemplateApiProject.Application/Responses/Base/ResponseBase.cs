using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApiProject.Application.Responses.Base
{
    public class ResponseBase
    {
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
