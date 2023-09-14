using ErrorOr;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Degre.Commands.Delete
{
    public class DeleteDegreCommandHandler : IRequestHandler<DeleteDegreCommand, ErrorOr<DeleteDegreCommandResult>>
    {
        private readonly IDegreeRepository _degreRepository;

        public DeleteDegreCommandHandler(IDegreeRepository degreRepository)
        {
            _degreRepository = degreRepository;
        }

        public async Task<ErrorOr<DeleteDegreCommandResult>> Handle(DeleteDegreCommand command, CancellationToken cancellationToken)
        {
            await _degreRepository.Delete(command.Id);

            return new DeleteDegreCommandResult();
        }
    }
}