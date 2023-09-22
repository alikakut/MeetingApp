using Mapster;
using MediatR;
using MeetingApp.Api.Contracts.Product.Commands;
using MeetingApp.Api.Contracts.Product.Queries;
using MeetingApp.Api.Controllers.Base;
using MeetingApp.Application.Features.Product.Commands.Create;
using MeetingApp.Application.Features.Product.Commands.Delete;
using MeetingApp.Application.Features.Product.Commands.Update;
using MeetingApp.Application.Features.Product.Queries.GetAll;
using MeetingApp.Application.Features.Product.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ApiResponse<GetByIdProductQueryResponse>(await _mediator.Send(new GetByIdProductQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
        {
            var command = request.Adapt<CreateProductCommand>();
            return await ApiResponse<CreateProductCommandResponse>(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
        {
            var command = request.Adapt<UpdateProductCommand>();
            return await ApiResponse<UpdateProductCommandResponse>(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ApiResponse<DeleteProductCommandResponse>(await _mediator.Send(new DeleteProductCommand { Id = id }));
        }
    }
}
