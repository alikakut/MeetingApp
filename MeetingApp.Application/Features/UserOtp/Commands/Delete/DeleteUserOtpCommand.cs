using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.UserOtp.Commands.Delete
{
    public class DeleteUserOtpCommand : IRequest<ErrorOr<DeleteUserOtpCommandResult>>
    {   
        public long Id { get; set; }
        
    }
}        