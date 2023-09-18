using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Package.Commands.Create
{
    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, ErrorOr<CreatePackageCommandResult>>
    {
        private readonly IPackageRepository _packageRepository;

        public CreatePackageCommandHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<ErrorOr<CreatePackageCommandResult>> Handle(CreatePackageCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<PackageEntity>();

            await _packageRepository.AddAsync(entity);

            return new CreatePackageCommandResult();
        }
    }
}        