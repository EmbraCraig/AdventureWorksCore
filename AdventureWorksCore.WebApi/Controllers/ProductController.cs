using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.AppRequests.Pagination;
using AdventureWorksCore.Application.Products.Commands.Create;
using AdventureWorksCore.Application.Products.Dtos;
using AdventureWorksCore.Application.Products.Queries.CartesianDemo;
using AdventureWorksCore.Application.Products.Queries.IncludeVsProjection;
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

    /// <summary>
    /// V1: Demonstrates cartesian explosion effect
    /// This endpoint shows the performance impact when multiple collections are included
    /// without using AsSplitQuery. Monitor the generated SQL to see the complex JOINs.
    /// </summary>
    [HttpGet("api/v1/products/{productId}/cartesian-demo")]
    public async Task<ActionResult<AppResponse<ProductDto>>> GetProductCartesianExplosion(
        [FromRoute] int productId,
        [FromServices] GetProductCartesianDemoQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(new() { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    /// <summary>
    /// V2: Demonstrates AsSplitQuery fix for cartesian explosion
    /// This endpoint shows the improved performance when AsSplitQuery is used.
    /// Multiple simpler queries are executed instead of one complex JOIN.
    /// </summary>
    [HttpGet("api/v2/products/{productId}/cartesian-demo")]
    public async Task<ActionResult<AppResponse<ProductDto>>> GetProductWithSplitQuery(
        [FromRoute] int productId,
        [FromServices] GetProductCartesianDemoQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.HandleV2(new() { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    /// <summary>
    /// V1: Demonstrates Include + MapFromEntity approach
    /// Uses Include statements to load full related entities, then maps to simplified DTO
    /// SQL: JOINs that load ALL columns from related tables (ProductModel, ProductSubcategory, etc.)
    /// Memory: Loads full entities into memory before mapping
    /// </summary>
    [HttpGet("api/v1/products/{productId}/include-vs-projection")]
    public async Task<ActionResult<AppResponse<ProductSummaryDto>>> GetProductWithInclude(
        [FromRoute] int productId,
        [FromServices] GetProductIncludeVsProjectionQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(new() { ProductId = productId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    /// <summary>
    /// V2: Demonstrates Projection approach
    /// Uses Select projection to only retrieve needed fields from related entities
    /// SQL: JOINs that only select REQUIRED columns (only Name fields from related tables)
    /// Memory: Only transfers needed data, no full entity loading
    /// </summary>
    [HttpGet("api/v2/products/{productId}/include-vs-projection")]
    public async Task<ActionResult<AppResponse<ProductSummaryDto>>> GetProductWithProjection(
        [FromRoute] int productId,
        [FromServices] GetProductIncludeVsProjectionQueryHandler handler,
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