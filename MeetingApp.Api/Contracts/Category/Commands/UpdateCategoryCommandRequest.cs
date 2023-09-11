using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Category.Commands
{
    public class UpdateCategoryCommandRequest : BaseResquestModel
    {
        public long Id { get; set; }    
        public string Name { get; set; }
    }
}
