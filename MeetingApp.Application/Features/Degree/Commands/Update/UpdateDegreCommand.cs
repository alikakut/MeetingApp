using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Degre.Commands.Update
{
    public class UpdateDegreCommand : IRequest<ErrorOr<UpdateDegreCommandResult>>
    {
        public long Id { get; set; }

        public string Description { get; set; }

    }
}