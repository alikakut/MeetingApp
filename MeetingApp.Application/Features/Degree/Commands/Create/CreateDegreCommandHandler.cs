using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Degre.Commands.Create
{
    public class CreateDegreCommandHandler : IRequestHandler<CreateDegreCommand, ErrorOr<CreateDegreCommandResult>>
    {
        private readonly IDegreeRepository _degreRepository;

        public CreateDegreCommandHandler(IDegreeRepository degreRepository)
        {
            _degreRepository = degreRepository;
        }

        public async Task<ErrorOr<CreateDegreCommandResult>> Handle(CreateDegreCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<DegreeEntity>();

            await _degreRepository.AddAsync(entity);

            return new CreateDegreCommandResult();
        }
    }
}        