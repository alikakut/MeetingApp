using FluentValidation;

namespace MeetingApp.Application.Features.Users.Commands.Create
{
    public class CreateUsersCommandValidator : AbstractValidator<CreateUsersCommand>
    {
        public CreateUsersCommandValidator()
        {
        }
    }
}        