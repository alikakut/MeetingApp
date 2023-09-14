using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Degre.Queries.GetAll;

public class GetAllDegreQuery : IRequest<ErrorOr<List<GetAllDegreQueryResult>>>
{
    //public DataFilterModel DataFilter { get; set; }
}        