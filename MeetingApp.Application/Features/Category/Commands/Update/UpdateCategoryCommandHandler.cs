using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<UpdateCategoryCommandResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<UpdateCategoryCommandResult>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<CategoryEntity>();

            await _categoryRepository.Update(entity);

            return new UpdateCategoryCommandResult();
        }
    }
}