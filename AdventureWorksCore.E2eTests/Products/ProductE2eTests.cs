using AdventureWorksCore.E2eTests.Shared.Dtos.Products;
using AdventureWorksCore.E2eTests.Shared.Endpoints;
using AdventureWorksCore.E2eTests.Shared.Extensions;
using AdventureWorksCore.E2eTests.Shared.WebApplicationFactory;
using FluentAssertions;
using Xunit.Abstractions;

namespace AdventureWorksCore.E2eTests.Products;

[Collection(CustomWebApplicationCollection.Name)]
public class ProductE2eTests : TestBase
{
    public ProductE2eTests(
        CustomWebApplicationFixture webApplicationFixture,
        ITestOutputHelper testOutputHelper) :
        base(webApplicationFixture, testOutputHelper)
    {
    }

    [Fact]
    public async Task ShouldReturnCreatedProductById()
    {
        var createResponse = await HttpClient.CreateProduct().Call(new() { Name = "Expected name", ProductNumber = Guid.NewGuid().ToString().Substring(0, 8) });

        await createResponse.Should().HaveStatusCode(201);

        var createdProductId = await createResponse.ReadResponseContentAs<int>();

        var getProductByIdResponse = await HttpClient.GetProductById().Call(createdProductId);

        await getProductByIdResponse.Should().HaveStatusCode(200);

        var returnedProduct = await getProductByIdResponse.ReadResponseContentAs<ProductDto>();

        returnedProduct.Name.Should().Be("Expected name");
    }

    [Fact]
    public async Task ShouldListCreatedProducts()
    {
        var product1Id = await HttpClient.CreateProduct().CallAndParseResponse(new() { Name = "Name 1", ProductNumber = Guid.NewGuid().ToString().Substring(0, 8) });
        var product2Id = await HttpClient.CreateProduct().CallAndParseResponse(new() { Name = "Name 2", ProductNumber = Guid.NewGuid().ToString().Substring(0, 8) });

        var listProductsResults = await HttpClient.ListProducts().CallAndParseResponse(new()
        {
            PageIndex = 1,
            PageSize = 5,
        });

        listProductsResults.Items.Should().HaveCount(2);
        listProductsResults.Items[0].Should().BeEquivalentTo(new ProductDto() { Id = product1Id, Name = "Name 1" });
        listProductsResults.Items[1].Id.Should().Be(product2Id);
    }

    [Fact]
    public async Task ShouldUpdateProduct()
    {
        var productId = await HttpClient.CreateProduct().CallAndParseResponse(new() { Name = "Name 1", ProductNumber = Guid.NewGuid().ToString().Substring(0, 8) });

        var updateResponse = await HttpClient.UpdateProduct().Call(new() { Id = productId, Name = "Updated name" });

        await updateResponse.Should().HaveStatusCode(200);

        var updatedProduct = await HttpClient.GetProductById().CallAndParseResponse(productId);

        updatedProduct.Should().BeEquivalentTo(new ProductDto() { Id = productId, Name = "Updated name" });
    }

    [Fact]
    public async Task ShouldDeleteProduct()
    {
        var productId1 = await HttpClient.CreateProduct().CallAndParseResponse(new() { Name = "Name 1", ProductNumber = Guid.NewGuid().ToString().Substring(0, 8) });
        var productId2 = await HttpClient.CreateProduct().CallAndParseResponse(new() { Name = "Name 2", ProductNumber = Guid.NewGuid().ToString().Substring(0, 8) });

        var deleteProductResponse = await HttpClient.DeleteProduct().Call(productId1);

        await deleteProductResponse.Should().HaveStatusCode(200);

        var listProductsResults = await HttpClient.ListProducts().CallAndParseResponse(new()
        {
            PageIndex = 1,
            PageSize = 5,
        });

        listProductsResults.Items.Should().HaveCount(1);
        listProductsResults.Items[0].Id.Should().Be(productId2);
    }
}
