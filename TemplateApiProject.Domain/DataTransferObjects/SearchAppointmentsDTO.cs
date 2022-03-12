using System;
using System.Collections.Generic;
using System.Text;
using TemplateApiProject.Domain.Enums;

namespace TemplateApiProject.Domain.DataTransferObjects
{
    public class SearchAppointmentsDTO
    {
        public Guid? PatientId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
