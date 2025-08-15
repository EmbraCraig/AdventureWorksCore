using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.AppRequests.Pagination;
using AdventureWorksCore.Application.Products.Commands.Create;
using AdventureWorksCore.Application.Projects.Commands.Delete;
using AdventureWorksCore.Application.Projects.Commands.Update;
using AdventureWorksCore.Application.Projects.Dtos;
using AdventureWorksCore.Application.Projects.Queries.GetById;
using AdventureWorksCore.Application.Projects.Queries.List;
using AdventureWorksCore.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksCore.WebApi.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("api/products")]
    public async Task<ActionResult<AppResponse<int>>> CreateProduct(
        [FromBody] CreateProductCommand command,
        [FromServices] CreateProductCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(command, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpGet("api/v1/products")]
    public async Task<ActionResult<AppResponse<PaginatedListResponse<ProductDto>>>> ListProducts(
        [FromQuery] ListProductsQuery query,
        [FromServices] ListProductsQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(query, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpGet("api/v2/products")]
    public async Task<ActionResult<AppResponse<PaginatedListResponse<ProductDto>>>> ListProductsV2(
    [FromQuery] ListProductsQuery query,
    [FromServices] ListProductsQueryHandler handler,
    CancellationToken cancellationToken)
    {
        var appResponse = await handler.HandleV2(query, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpGet("api/v1/products/{productId}")]
    public async Task<ActionResult<AppResponse<ProductDto>>> GetProductById(
        [FromRoute] int productId,
        [FromServices] GetProductByIdQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(new() { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpGet("api/v2/products/{productId}")]
    public async Task<ActionResult<AppResponse<ProductDto>>> GetProductByIdV2(
        [FromRoute] int productId,
        [FromServices] GetProductByIdQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.HandleV2(new() { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpPut("api/products/{productId}")]
    public async Task<ActionResult<AppResponse>> UpdateProduct(
        [FromRoute] int productId,
        [FromBody] UpdateProductCommand command,
        [FromServices] UpdateProductCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(command with { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpDelete("api/products/{productId}")]
    public async Task<ActionResult<AppResponse>> DeleteProject(
        [FromRoute] int productId,
        [FromServices] DeleteProductCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(new() { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }
}