using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TemplateApiProject.Application.Responses;
using TemplateApiProject.Application.ViewModel;

namespace TemplateApiProject.Application.Requests
{
    public class FindUserRequest : IRequest<Response>
    {
        public Guid Id { get; set; }

        public FindUserRequest() { }

        public FindUserRequest(Guid id)
        {
            Id = id;
        }
    }
}
