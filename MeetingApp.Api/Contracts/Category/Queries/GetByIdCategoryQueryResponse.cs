using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Category.Queries
{
    public class GetByIdCategoryQueryResponse : BaseResponseModel
    {
        public string Name { get; set; }    
    }
}
