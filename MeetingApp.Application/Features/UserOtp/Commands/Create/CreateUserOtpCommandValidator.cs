using FluentValidation;

namespace MeetingApp.Application.Features.UserOtp.Commands.Create
{
    public class CreateUserOtpCommandValidator : AbstractValidator<CreateUserOtpCommand>
    {
        public CreateUserOtpCommandValidator()
        {
        }
    }
}        