using ErrorOr;
using MediatR;
using MeetingApp.Application.Utilities.Sieve;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetAll;

public class GetAllUserOtpQuery : IRequest<ErrorOr<List<GetAllUserOtpQueryResult>>>
{
    public DataFilterModel DataFilter { get; set; }
}        