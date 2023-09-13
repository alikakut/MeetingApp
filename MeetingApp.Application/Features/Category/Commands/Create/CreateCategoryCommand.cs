using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<ErrorOr<CreateCategoryCommandResult>>
    {


        public string Name { get; set; }

    }
}