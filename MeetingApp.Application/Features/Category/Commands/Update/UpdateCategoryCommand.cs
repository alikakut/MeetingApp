using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<ErrorOr<UpdateCategoryCommandResult>>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}