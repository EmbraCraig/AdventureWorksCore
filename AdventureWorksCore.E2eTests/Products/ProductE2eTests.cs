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
        var createCommand = new CreateProductDto
        {
            Name = "Expected name",
            ProductNumber = Guid.NewGuid().ToString().Substring(0, 8),
            MakeFlag = true,
            FinishedGoodsFlag = true,
            Color = "Red",
            SafetyStockLevel = 10,
            ReorderPoint = 5,
            StandardCost = 100.00m,
            ListPrice = 150.00m,
            Size = "M",
            SizeUnitMeasureCode = "CM",
            WeightUnitMeasureCode = "KG",
            Weight = 1.5m,
            DaysToManufacture = 2,
            ProductLine = "R",
            Class = "H",
            Style = "M"
        };

        var createResponse = await HttpClient.CreateProduct().Call(createCommand);

        await createResponse.Should().HaveStatusCode(201);

        var createdProductId = await createResponse.ReadResponseContentAs<int>();

        var getProductByIdResponse = await HttpClient.GetProductById().Call(createdProductId);

        await getProductByIdResponse.Should().HaveStatusCode(200);

        var returnedProduct = await getProductByIdResponse.ReadResponseContentAs<ProductDto>();

        returnedProduct.Should().BeEquivalentTo(new ProductDto
        {
            Id = createdProductId,
            Name = createCommand.Name,
            ProductNumber = createCommand.ProductNumber,
            MakeFlag = createCommand.MakeFlag,
            FinishedGoodsFlag = createCommand.FinishedGoodsFlag,
            Color = createCommand.Color,
            SafetyStockLevel = createCommand.SafetyStockLevel,
            ReorderPoint = createCommand.ReorderPoint,
            StandardCost = createCommand.StandardCost,
            ListPrice = createCommand.ListPrice,
            Size = createCommand.Size,
            SizeUnitMeasureCode = createCommand.SizeUnitMeasureCode,
            WeightUnitMeasureCode = createCommand.WeightUnitMeasureCode,
            Weight = createCommand.Weight,
            DaysToManufacture = createCommand.DaysToManufacture,
            ProductLine = createCommand.ProductLine,
            Class = createCommand.Class,
            Style = createCommand.Style,
            ProductReviews = [],
            ProductPhotos = []
        }, options => options.Excluding(p => p.SellStartDate).Excluding(p => p.ModifiedDate));
    }

    [Fact]
    public async Task ShouldListCreatedProducts()
    {
        var product1Command = new CreateProductDto
        {
            Name = "Name 1",
            ProductNumber = Guid.NewGuid().ToString().Substring(0, 8),
            MakeFlag = true,
            FinishedGoodsFlag = true,
            Color = "Blue",
            SafetyStockLevel = 10,
            ReorderPoint = 5,
            StandardCost = 100.00m,
            ListPrice = 150.00m
        };

        var product2Command = new CreateProductDto
        {
            Name = "Name 2",
            ProductNumber = Guid.NewGuid().ToString().Substring(0, 8),
            MakeFlag = false,
            FinishedGoodsFlag = true,
            Color = "Green",
            SafetyStockLevel = 15,
            ReorderPoint = 8,
            StandardCost = 200.00m,
            ListPrice = 300.00m
        };

        var product1Id = await HttpClient.CreateProduct().CallAndParseResponse(product1Command);
        var product2Id = await HttpClient.CreateProduct().CallAndParseResponse(product2Command);

        var listProductsResults = await HttpClient.ListProducts().CallAndParseResponse(new()
        {
            PageIndex = 1,
            PageSize = 5,
        });

        listProductsResults.Items.Should().HaveCount(2);
        listProductsResults.Items[0].Should().BeEquivalentTo(new ProductDto
        {
            Id = product1Id,
            Name = product1Command.Name,
            ProductNumber = product1Command.ProductNumber,
            MakeFlag = product1Command.MakeFlag,
            FinishedGoodsFlag = product1Command.FinishedGoodsFlag,
            Color = product1Command.Color,
            SafetyStockLevel = product1Command.SafetyStockLevel,
            ReorderPoint = product1Command.ReorderPoint,
            StandardCost = product1Command.StandardCost,
            ListPrice = product1Command.ListPrice,
            ProductReviews = [],
            ProductPhotos = []
        }, options => options.Excluding(p => p.SellStartDate).Excluding(p => p.ModifiedDate));

        listProductsResults.Items[1].Should().BeEquivalentTo(new ProductDto
        {
            Id = product2Id,
            Name = product2Command.Name,
            ProductNumber = product2Command.ProductNumber,
            MakeFlag = product2Command.MakeFlag,
            FinishedGoodsFlag = product2Command.FinishedGoodsFlag,
            Color = product2Command.Color,
            SafetyStockLevel = product2Command.SafetyStockLevel,
            ReorderPoint = product2Command.ReorderPoint,
            StandardCost = product2Command.StandardCost,
            ListPrice = product2Command.ListPrice,
            ProductReviews = [],
            ProductPhotos = []
        }, options => options.Excluding(p => p.SellStartDate).Excluding(p => p.ModifiedDate));
    }

    [Fact]
    public async Task ShouldUpdateProduct()
    {
        var createCommand = new CreateProductDto
        {
            Name = "Name 1",
            ProductNumber = Guid.NewGuid().ToString().Substring(0, 8),
            MakeFlag = true,
            FinishedGoodsFlag = true,
            Color = "Red",
            SafetyStockLevel = 10,
            ReorderPoint = 5,
            StandardCost = 100.00m,
            ListPrice = 150.00m
        };

        var productId = await HttpClient.CreateProduct().CallAndParseResponse(createCommand);

        var updateCommand = new UpdateProductDto
        {
            Id = productId,
            Name = "Updated name",
            ProductNumber = createCommand.ProductNumber,
            MakeFlag = false,
            FinishedGoodsFlag = true,
            Color = "Blue",
            SafetyStockLevel = 15,
            ReorderPoint = 8,
            StandardCost = 200.00m,
            ListPrice = 300.00m,
            Size = "L",
            SizeUnitMeasureCode = "CM",
            WeightUnitMeasureCode = "KG",
            Weight = 2.0m,
            DaysToManufacture = 3,
            ProductLine = "M",
            Class = "M",
            Style = "U",
            SellEndDate = DateTime.UtcNow.AddDays(30)
        };

        var updateResponse = await HttpClient.UpdateProduct().Call(updateCommand);

        await updateResponse.Should().HaveStatusCode(200);

        var updatedProduct = await HttpClient.GetProductById().CallAndParseResponse(productId);

        updatedProduct.Should().BeEquivalentTo(new ProductDto
        {
            Id = productId,
            Name = updateCommand.Name,
            ProductNumber = updateCommand.ProductNumber,
            MakeFlag = updateCommand.MakeFlag,
            FinishedGoodsFlag = updateCommand.FinishedGoodsFlag,
            Color = updateCommand.Color,
            SafetyStockLevel = updateCommand.SafetyStockLevel,
            ReorderPoint = updateCommand.ReorderPoint,
            StandardCost = updateCommand.StandardCost,
            ListPrice = updateCommand.ListPrice,
            Size = updateCommand.Size,
            SizeUnitMeasureCode = updateCommand.SizeUnitMeasureCode,
            WeightUnitMeasureCode = updateCommand.WeightUnitMeasureCode,
            Weight = updateCommand.Weight,
            DaysToManufacture = updateCommand.DaysToManufacture,
            ProductLine = updateCommand.ProductLine,
            Class = updateCommand.Class,
            Style = updateCommand.Style,
            SellEndDate = updateCommand.SellEndDate,
            ProductReviews = [],
            ProductPhotos = []
        }, options => options.Excluding(p => p.SellStartDate).Excluding(p => p.ModifiedDate));
    }

    [Fact]
    public async Task ShouldDeleteProduct()
    {
        var product1Command = new CreateProductDto
        {
            Name = "Name 1",
            ProductNumber = Guid.NewGuid().ToString().Substring(0, 8),
            MakeFlag = true,
            FinishedGoodsFlag = true,
            Color = "Red",
            SafetyStockLevel = 10,
            ReorderPoint = 5,
            StandardCost = 100.00m,
            ListPrice = 150.00m
        };

        var product2Command = new CreateProductDto
        {
            Name = "Name 2",
            ProductNumber = Guid.NewGuid().ToString().Substring(0, 8),
            MakeFlag = false,
            FinishedGoodsFlag = true,
            Color = "Green",
            SafetyStockLevel = 15,
            ReorderPoint = 8,
            StandardCost = 200.00m,
            ListPrice = 300.00m
        };

        var productId1 = await HttpClient.CreateProduct().CallAndParseResponse(product1Command);
        var productId2 = await HttpClient.CreateProduct().CallAndParseResponse(product2Command);

        var deleteProductResponse = await HttpClient.DeleteProduct().Call(productId1);

        await deleteProductResponse.Should().HaveStatusCode(200);

        var listProductsResults = await HttpClient.ListProducts().CallAndParseResponse(new()
        {
            PageIndex = 1,
            PageSize = 5,
        });

        listProductsResults.Items.Should().HaveCount(1);
        listProductsResults.Items[0].Should().BeEquivalentTo(new ProductDto
        {
            Id = productId2,
            Name = product2Command.Name,
            ProductNumber = product2Command.ProductNumber,
            MakeFlag = product2Command.MakeFlag,
            FinishedGoodsFlag = product2Command.FinishedGoodsFlag,
            Color = product2Command.Color,
            SafetyStockLevel = product2Command.SafetyStockLevel,
            ReorderPoint = product2Command.ReorderPoint,
            StandardCost = product2Command.StandardCost,
            ListPrice = product2Command.ListPrice,
            ProductReviews = [],
            ProductPhotos = []
        }, options => options.Excluding(p => p.SellStartDate).Excluding(p => p.ModifiedDate));
    }
}
