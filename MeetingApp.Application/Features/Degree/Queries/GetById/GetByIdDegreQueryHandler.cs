using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Degre.Queries.GetById
{
    public class GetByIdDegreQueryHandler : IRequestHandler<GetByIdDegreQuery, ErrorOr<GetByIdDegreQueryResult>>
    {
        private readonly IDegreeRepository _degreRepository;

        public GetByIdDegreQueryHandler(IDegreeRepository degreRepository)
        {
            _degreRepository = degreRepository;
        }

        public async Task<ErrorOr<GetByIdDegreQueryResult>> Handle(GetByIdDegreQuery request, CancellationToken cancellationToken)
        {
            var data = await _degreRepository.GetByIdAsync(request.Id);

            return data.Adapt<GetByIdDegreQueryResult>();
        }
    }
}  