using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Degre.Commands.Create
{
    public class CreateDegreCommand : IRequest<ErrorOr<CreateDegreCommandResult>>
    {


        public string Description { get; set; }

    }
}