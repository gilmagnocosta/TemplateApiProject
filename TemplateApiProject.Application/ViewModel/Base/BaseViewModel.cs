using System;

namespace TemplateApiProject.Application.ViewModel.Base
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
