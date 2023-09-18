using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetById;

public class GetByIdUserOtpQuery : IRequest<ErrorOr<GetByIdUserOtpQueryResult>>
{
    public long Id { get; set; }
}        