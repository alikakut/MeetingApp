using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandResult : BaseEntity
    {

        public string Name { get; set; }

    }
}