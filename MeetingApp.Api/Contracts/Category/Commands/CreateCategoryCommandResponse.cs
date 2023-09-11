using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Category.Commands
{
    public class CreateCategoryCommandResponse : BaseResponseModel
    {
        public string Name { get; set; }
    }
}
