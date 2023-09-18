using FluentValidation;

namespace MeetingApp.Application.Features.Product.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
        }
    }
}        