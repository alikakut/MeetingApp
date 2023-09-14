using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Degre.Queries.GetAll
{
    public class GetAllDegreQueryHandler : IRequestHandler<GetAllDegreQuery, ErrorOr<List<GetAllDegreQueryResult>>>
    {
        private readonly IDegreeRepository _degreRepository;

        public GetAllDegreQueryHandler(IDegreeRepository degreRepository)
        {
            _degreRepository = degreRepository;
        }

        public async Task<ErrorOr<List<GetAllDegreQueryResult>>> Handle(GetAllDegreQuery request, CancellationToken cancellationToken)
        {
            var data = ToString(); //await _degreRepository.GetAll(request.DataFilter);

            return data.Adapt<List<GetAllDegreQueryResult>>();
        }
    }
}        