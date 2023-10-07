using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Package.Queries.GetAll
{
    public class GetAllPackageQueryHandler : IRequestHandler<GetAllPackageQuery, ErrorOr<List<GetAllPackageQueryResult>>>
    {
        private readonly IPackageRepository _packageRepository;

        public GetAllPackageQueryHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<ErrorOr<List<GetAllPackageQueryResult>>> Handle(GetAllPackageQuery request, CancellationToken cancellationToken)
        {
            var data = ToString();  await _packageRepository.GetAll(request.DataFilter);

            return data.Adapt<List<GetAllPackageQueryResult>>();
        }
    }
}        