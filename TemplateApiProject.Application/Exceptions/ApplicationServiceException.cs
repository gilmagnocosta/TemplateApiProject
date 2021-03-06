using System;

namespace TemplateApiProject.Application.Exceptions
{
    public class ApplicationServiceException : Exception
    {
        public ApplicationServiceException(string message) { }
        public ApplicationServiceException(string message, Exception exception) : base(message, exception) { }
    }
}
