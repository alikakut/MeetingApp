using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Degre.Commands.Update
{
    public class UpdateDegreCommandHandler : IRequestHandler<UpdateDegreCommand, ErrorOr<UpdateDegreCommandResult>>
    {
        private readonly IDegreeRepository _degreRepository;

        public UpdateDegreCommandHandler(IDegreeRepository degreRepository)
        {
            _degreRepository = degreRepository;
        }

        public async Task<ErrorOr<UpdateDegreCommandResult>> Handle(UpdateDegreCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<DegreeEntity>();

            await _degreRepository.Update(entity);

            return new UpdateDegreCommandResult();
        }
    }
}