using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Category.Commands
{
    public class CreateCategoryCommandRequest : BaseResquestModel
    {
        public string Name { get; set; }
    }
}
