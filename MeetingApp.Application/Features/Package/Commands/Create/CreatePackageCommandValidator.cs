using FluentValidation;

namespace MeetingApp.Application.Features.Package.Commands.Create
{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public CreatePackageCommandValidator()
        {
        }
    }
}        