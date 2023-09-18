using FluentValidation;

namespace MeetingApp.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
        }
    }
}        