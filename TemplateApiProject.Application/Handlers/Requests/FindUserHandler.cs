using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TemplateApiProject.Application.Requests;
using TemplateApiProject.Application.Responses;
using TemplateApiProject.Application.ViewModel;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Notifications;

namespace TemplateApiProject.Application.Handlers.Requests
{
    public class FindUserHandler : IRequestHandler<FindUserRequest, Response>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        
        
        public FindUserHandler(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response> Handle(FindUserRequest request, CancellationToken cancellationToken)
        {
            var entity = await _service.FindByAsync(x=>x.Id == request.Id);
            return await Task.FromResult(new Response(_mapper.Map<FindUserResponse>(entity)));
        }
    }
}