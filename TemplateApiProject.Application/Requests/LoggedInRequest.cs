using MediatR;
using System;
using TemplateApiProject.Application.Responses;

namespace TemplateApiProject.Application.Requests
{
    public class LoggedInRequest : IRequest<Response>
    {
        public Guid UsedId { get; set; }

        public LoggedInRequest() { }

        public LoggedInRequest(Guid userId)
        {
            UsedId = userId;
        }
    }
}
