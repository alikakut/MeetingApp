using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Package.Commands.Delete
{
    public class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommand, ErrorOr<DeletePackageCommandResult>>
    {
        private readonly IPackageRepository _packageRepository;

        public DeletePackageCommandHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<ErrorOr<DeletePackageCommandResult>> Handle(DeletePackageCommand command, CancellationToken cancellationToken)
        {
            await _packageRepository.Delete(command.Id);

            return new DeletePackageCommandResult();
        }
    }
}