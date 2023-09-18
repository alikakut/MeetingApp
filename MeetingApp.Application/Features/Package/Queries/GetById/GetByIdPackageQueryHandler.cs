using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Package.Queries.GetById
{
    public class GetByIdPackageQueryHandler : IRequestHandler<GetByIdPackageQuery, ErrorOr<GetByIdPackageQueryResult>>
    {
        private readonly IPackageRepository _packageRepository;

        public GetByIdPackageQueryHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<ErrorOr<GetByIdPackageQueryResult>> Handle(GetByIdPackageQuery request, CancellationToken cancellationToken)
        {
            var data = await _packageRepository.GetByIdAsync(request.Id);

            return data.Adapt<GetByIdPackageQueryResult>();
        }
    }
}  