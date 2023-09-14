using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Degre.Queries.GetById;

public class GetByIdDegreQuery : IRequest<ErrorOr<GetByIdDegreQueryResult>>
{
    public long Id { get; set; }
}        