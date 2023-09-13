using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandResult : BaseEntity
    {

        public string Name { get; set; }

    }
}