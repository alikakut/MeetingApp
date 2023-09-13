using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<DeleteCategoryCommandResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<DeleteCategoryCommandResult>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            await _categoryRepository.Delete(command.Id);

            return new DeleteCategoryCommandResult();
        }
    }
}