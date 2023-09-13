using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandResult : BaseEntity
    {

        public string Name { get; set; }

    }
}