using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetAll;

public class GetAllUserOtpQuery : IRequest<ErrorOr<List<GetAllUserOtpQueryResult>>>
{
   // public DataFilterModel DataFilter { get; set; }
}        