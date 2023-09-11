using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Category.Commands
{
    public class UpdateCategoryCommandResponse : BaseResponseModel
    {
        public string Name { get; set; }
    }
}
