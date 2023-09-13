using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<CreateCategoryCommandResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<CreateCategoryCommandResult>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<CategoryEntity>();

           // await _categoryRepository.AddAsync(entity);

            return new CreateCategoryCommandResult();
        }
    }
}        