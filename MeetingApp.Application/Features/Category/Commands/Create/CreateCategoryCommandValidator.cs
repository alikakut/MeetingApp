using FluentValidation;

namespace MeetingApp.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
        }
    }
}        