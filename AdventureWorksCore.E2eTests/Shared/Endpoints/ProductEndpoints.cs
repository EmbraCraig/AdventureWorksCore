using AdventureWorksCore.Application.Common.AppRequests.Pagination;
using AdventureWorksCore.E2eTests.Shared.Dtos.Products;
using AdventureWorksCore.E2eTests.Shared.Endpoints.Base;
using System.Net.Http.Json;

namespace AdventureWorksCore.E2eTests.Shared.Endpoints;

internal static class ProductHttpClientExtensions
{
    public static CreateProductEndpoint CreateProduct(this HttpClient httpClient) => new(httpClient);
    public static GetProductByIdEndpoint GetProductById(this HttpClient httpClient) => new(httpClient);
    public static ListProductsEndpoint ListProducts(this HttpClient httpClient) => new(httpClient);
    public static UpdateProductEndpoint UpdateProduct(this HttpClient httpClient) => new(httpClient);
    public static DeleteProductEndpoint DeleteProduct(this HttpClient httpClient) => new(httpClient);
}

internal class CreateProductEndpoint : ApiEndpointBase<CreateProductDto, int>
{
    internal CreateProductEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(CreateProductDto dto)
    {
        var path = "api/products";

        return await HttpClient.PostAsJsonAsync(path, dto);
    }
}

internal class GetProductByIdEndpoint : ApiEndpointBase<int, ProductDto>
{
    internal GetProductByIdEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(int productId)
    {
        var path = $"api/products/{productId}";

        return await HttpClient.GetAsync(path);
    }
}

internal class ListProductsEndpoint : ApiEndpointBase<PaginatedListQuery, PaginatedListResponse<ProductDto>>
{
    public ListProductsEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(PaginatedListQuery dto)
    {
        var path = $"api/products?{dto.ToQueryString()}";

        return await HttpClient.GetAsync(path);
    }
}

internal class UpdateProductEndpoint : ApiEndpointBaseWithoutResponse<UpdateProductDto>
{
    internal UpdateProductEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(UpdateProductDto dto)
    {
        var path = $"api/products/{dto.Id}";

        return await HttpClient.PutAsJsonAsync(path, dto);
    }
}

internal class DeleteProductEndpoint : ApiEndpointBaseWithoutResponse<int>
{
    public DeleteProductEndpoint(HttpClient httpClient) : base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(int productId)
    {
        return await HttpClient.DeleteAsync($"api/products/{productId}");
    }
}