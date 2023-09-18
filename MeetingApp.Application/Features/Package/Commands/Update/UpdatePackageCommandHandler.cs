using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Package.Commands.Update
{
    public class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommand, ErrorOr<UpdatePackageCommandResult>>
    {
        private readonly IPackageRepository _packageRepository;

        public UpdatePackageCommandHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<ErrorOr<UpdatePackageCommandResult>> Handle(UpdatePackageCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<PackageEntity>();

            await _packageRepository.Update(entity);

            return new UpdatePackageCommandResult();
        }
    }
}