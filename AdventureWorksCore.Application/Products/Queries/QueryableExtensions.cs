using AdventureWorksCore.Application.Projects.Dtos;
using AdventureWorksCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Products.Queries;
public static class QueryableExtensions
{
    public static IQueryable<ProductDto> ProjectToDto(this IQueryable<Product> queryable)
    {
        return queryable.Select(entity => new ProductDto
        {
            Id = entity.ProductId,
            Name = entity.Name,
            ProductNumber = entity.ProductNumber,
            MakeFlag = entity.MakeFlag,
            FinishedGoodsFlag = entity.FinishedGoodsFlag,
            Color = entity.Color,
            SafetyStockLevel = entity.SafetyStockLevel,
            ReorderPoint = entity.ReorderPoint,
            StandardCost = entity.StandardCost,
            ListPrice = entity.ListPrice,
            Size = entity.Size,
            SizeUnitMeasureCode = entity.SizeUnitMeasureCode != null ? entity.SizeUnitMeasureCode.Trim() : null,
            WeightUnitMeasureCode = entity.WeightUnitMeasureCode != null ? entity.WeightUnitMeasureCode.Trim() : null,
            Weight = entity.Weight,
            DaysToManufacture = entity.DaysToManufacture,
            ProductLine = entity.ProductLine != null ? entity.ProductLine.Trim() : null,
            Class = entity.Class != null ? entity.Class.Trim() : null,
            Style = entity.Style != null ? entity.Style.Trim() : null,
            SellStartDate = entity.SellStartDate,
            SellEndDate = entity.SellEndDate,
            DiscontinuedDate = entity.DiscontinuedDate,
            ModifiedDate = entity.ModifiedDate,
            ProductModel = entity.ProductModel != null ? new ProductModelDto
            {
                Id = entity.ProductModel.ProductModelId,
                Name = entity.ProductModel.Name,
                CatalogDescription = entity.ProductModel.CatalogDescription,
                Instructions = entity.ProductModel.Instructions,
                ModifiedDate = entity.ProductModel.ModifiedDate
            } : null,
            ProductSubcategory = entity.ProductSubcategory != null ? new ProductSubcategoryDto
            {
                Id = entity.ProductSubcategory.ProductSubcategoryId,
                Name = entity.ProductSubcategory.Name,
                ProductCategoryId = entity.ProductSubcategory.ProductCategoryId,
                ProductCategoryName = entity.ProductSubcategory.ProductCategory.Name,
                ModifiedDate = entity.ProductSubcategory.ModifiedDate
            } : null,
            ProductReviews = entity.ProductReviews.Select(pr => new ProductReviewDto
            {
                Id = pr.ProductReviewId,
                ReviewerName = pr.ReviewerName,
                ReviewDate = pr.ReviewDate,
                EmailAddress = pr.EmailAddress,
                Rating = pr.Rating,
                Comments = pr.Comments,
                ModifiedDate = pr.ModifiedDate
            }).ToList(),
            ProductPhotos = entity.ProductProductPhotos.Select(ppp => new ProductPhotoDto
            {
                Id = ppp.ProductPhoto.ProductPhotoId,
                ThumbnailPhotoFileName = ppp.ProductPhoto.ThumbnailPhotoFileName,
                LargePhotoFileName = ppp.ProductPhoto.LargePhotoFileName,
                ModifiedDate = ppp.ProductPhoto.ModifiedDate
            }).ToList(),
            BillOfMaterialComponents = entity.BillOfMaterialComponents.Select(bom => new BillOfMaterialDto
            {
                BillOfMaterialsId = bom.BillOfMaterialsId,
                ProductAssemblyId = bom.ProductAssemblyId,
                ComponentId = bom.ComponentId,
                StartDate = bom.StartDate,
                EndDate = bom.EndDate,
                UnitMeasureCode = bom.UnitMeasureCode,
                UnitMeasureName = bom.UnitMeasureCodeNavigation != null ? bom.UnitMeasureCodeNavigation.Name : null,
                Bomlevel = bom.Bomlevel,
                PerAssemblyQty = bom.PerAssemblyQty,
                ModifiedDate = bom.ModifiedDate,
                Component = bom.Component != null ? new SubProductDto { Id = bom.Component.ProductId, Name = bom.Component.Name } : null,
                ProductAssembly = bom.ProductAssembly != null ? new SubProductDto { Id = bom.ProductAssembly.ProductId, Name = bom.ProductAssembly.Name } : null
            }).ToList(),
            BillOfMaterialProductAssemblies = entity.BillOfMaterialProductAssemblies.Select(bom => new BillOfMaterialDto
            {
                BillOfMaterialsId = bom.BillOfMaterialsId,
                ProductAssemblyId = bom.ProductAssemblyId,
                ComponentId = bom.ComponentId,
                StartDate = bom.StartDate,
                EndDate = bom.EndDate,
                UnitMeasureCode = bom.UnitMeasureCode,
                UnitMeasureName = bom.UnitMeasureCodeNavigation != null ? bom.UnitMeasureCodeNavigation.Name : null,
                Bomlevel = bom.Bomlevel,
                PerAssemblyQty = bom.PerAssemblyQty,
                ModifiedDate = bom.ModifiedDate,
                Component = bom.Component != null ? new SubProductDto { Id = bom.Component.ProductId, Name = bom.Component.Name } : null,
                ProductAssembly = bom.ProductAssembly != null ? new SubProductDto { Id = bom.ProductAssembly.ProductId, Name = bom.ProductAssembly.Name } : null
            }).ToList(),
            ProductCostHistories = entity.ProductCostHistories.Select(pch => new ProductCostHistoryDto
            {
                ProductId = pch.ProductId,
                StartDate = pch.StartDate,
                EndDate = pch.EndDate,
                StandardCost = pch.StandardCost,
                ModifiedDate = pch.ModifiedDate
            }).ToList(),
            ProductInventories = entity.ProductInventories.Select(pi => new ProductInventoryDto
            {
                ProductId = pi.ProductId,
                LocationId = pi.LocationId,
                Shelf = pi.Shelf,
                Bin = pi.Bin,
                Quantity = pi.Quantity,
                Rowguid = pi.Rowguid,
                ModifiedDate = pi.ModifiedDate,
                LocationName = pi.Location.Name
            }).ToList(),
            ProductListPriceHistories = entity.ProductListPriceHistories.Select(plph => new ProductListPriceHistoryDto
            {
                ProductId = plph.ProductId,
                StartDate = plph.StartDate,
                EndDate = plph.EndDate,
                ListPrice = plph.ListPrice,
                ModifiedDate = plph.ModifiedDate
            }).ToList(),
            ProductVendors = entity.ProductVendors.Select(pv => new ProductVendorDto
            {
                ProductId = pv.ProductId,
                BusinessEntityId = pv.BusinessEntityId,
                AverageLeadTime = pv.AverageLeadTime,
                StandardPrice = pv.StandardPrice,
                LastReceiptCost = pv.LastReceiptCost,
                LastReceiptDate = pv.LastReceiptDate,
                MinOrderQty = pv.MinOrderQty,
                MaxOrderQty = pv.MaxOrderQty,
                OnOrderQty = pv.OnOrderQty,
                UnitMeasureCode = pv.UnitMeasureCode,
                UnitMeasureName = pv.UnitMeasureCodeNavigation.Name,
                ModifiedDate = pv.ModifiedDate,
                Vendor = new VendorDto
                {
                    BusinessEntityId = pv.BusinessEntity.BusinessEntityId,
                    AccountNumber = pv.BusinessEntity.AccountNumber,
                    Name = pv.BusinessEntity.Name,
                    CreditRating = pv.BusinessEntity.CreditRating,
                    PreferredVendorStatus = pv.BusinessEntity.PreferredVendorStatus,
                    ActiveFlag = pv.BusinessEntity.ActiveFlag,
                    PurchasingWebServiceUrl = pv.BusinessEntity.PurchasingWebServiceUrl,
                    ModifiedDate = pv.BusinessEntity.ModifiedDate
                }
            }).ToList(),
            PurchaseOrderDetails = entity.PurchaseOrderDetails.Select(pod => new PurchaseOrderDetailDto
            {
                PurchaseOrderId = pod.PurchaseOrderId,
                PurchaseOrderDetailId = pod.PurchaseOrderDetailId,
                DueDate = pod.DueDate,
                OrderQty = pod.OrderQty,
                ProductId = pod.ProductId,
                UnitPrice = pod.UnitPrice,
                LineTotal = pod.LineTotal,
                ReceivedQty = pod.ReceivedQty,
                RejectedQty = pod.RejectedQty,
                StockedQty = pod.StockedQty,
                ModifiedDate = pod.ModifiedDate,
                PurchaseOrder = new PurchaseOrderHeaderDto
                {
                    PurchaseOrderId = pod.PurchaseOrder.PurchaseOrderId,
                    RevisionNumber = pod.PurchaseOrder.RevisionNumber,
                    Status = pod.PurchaseOrder.Status,
                    EmployeeId = pod.PurchaseOrder.EmployeeId,
                    VendorId = pod.PurchaseOrder.VendorId,
                    ShipMethodId = pod.PurchaseOrder.ShipMethodId,
                    OrderDate = pod.PurchaseOrder.OrderDate,
                    ShipDate = pod.PurchaseOrder.ShipDate,
                    SubTotal = pod.PurchaseOrder.SubTotal,
                    TaxAmt = pod.PurchaseOrder.TaxAmt,
                    Freight = pod.PurchaseOrder.Freight,
                    TotalDue = pod.PurchaseOrder.TotalDue,
                    ModifiedDate = pod.PurchaseOrder.ModifiedDate
                }
            }).ToList(),
            WorkOrders = entity.WorkOrders.Select(wo => new WorkOrderDto
            {
                WorkOrderId = wo.WorkOrderId,
                ProductId = wo.ProductId,
                OrderQty = wo.OrderQty,
                StockedQty = wo.StockedQty,
                ScrappedQty = wo.ScrappedQty,
                StartDate = wo.StartDate,
                EndDate = wo.EndDate,
                DueDate = wo.DueDate,
                ScrapReasonId = wo.ScrapReasonId,
                ScrapReasonName = wo.ScrapReason != null ? wo.ScrapReason.Name : null,
                ModifiedDate = wo.ModifiedDate,
                WorkOrderRoutings = wo.WorkOrderRoutings.Select(wor => new WorkOrderRoutingDto
                {
                    WorkOrderId = wor.WorkOrderId,
                    ProductId = wor.ProductId,
                    OperationSequence = wor.OperationSequence,
                    LocationId = wor.LocationId,
                    LocationName = wor.Location.Name,
                    ScheduledStartDate = wor.ScheduledStartDate,
                    ScheduledEndDate = wor.ScheduledEndDate,
                    ActualStartDate = wor.ActualStartDate,
                    ActualEndDate = wor.ActualEndDate,
                    ActualResourceHrs = wor.ActualResourceHrs,
                    PlannedCost = wor.PlannedCost,
                    ActualCost = wor.ActualCost,
                    ModifiedDate = wor.ModifiedDate
                }).ToList()
            })
            .ToList()
        }).AsSplitQuery();
    }
}
