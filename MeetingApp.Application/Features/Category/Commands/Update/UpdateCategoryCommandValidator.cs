using FluentValidation;

namespace MeetingApp.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
        }
    }
}        