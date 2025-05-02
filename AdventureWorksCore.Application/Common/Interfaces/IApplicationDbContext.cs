using AdventureWorksCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Address> Addresses { get; }

    public DbSet<AddressType> AddressTypes { get; }

    public DbSet<AwbuildVersion> AwbuildVersions { get; }

    public DbSet<BillOfMaterial> BillOfMaterials { get; }

    public DbSet<BusinessEntity> BusinessEntities { get; }

    public DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; }

    public DbSet<BusinessEntityContact> BusinessEntityContacts { get; }

    public DbSet<ContactType> ContactTypes { get; }

    public DbSet<CountryRegion> CountryRegions { get; }

    public DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; }

    public DbSet<CreditCard> CreditCards { get; }

    public DbSet<Culture> Cultures { get; }

    public DbSet<Currency> Currencies { get; }

    public DbSet<CurrencyRate> CurrencyRates { get; }

    public DbSet<Customer> Customers { get; }

    public DbSet<DatabaseLog> DatabaseLogs { get; }

    public DbSet<Department> Departments { get; }

    public DbSet<EmailAddress> EmailAddresses { get; }

    public DbSet<Employee> Employees { get; }

    public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; }

    public DbSet<EmployeePayHistory> EmployeePayHistories { get; }

    public DbSet<ErrorLog> ErrorLogs { get; }

    public DbSet<Illustration> Illustrations { get; }

    public DbSet<JobCandidate> JobCandidates { get; }

    public DbSet<Location> Locations { get; }

    public DbSet<Password> Passwords { get; }

    public DbSet<Person> People { get; }

    public DbSet<PersonCreditCard> PersonCreditCards { get; }

    public DbSet<PersonPhone> PersonPhones { get; }

    public DbSet<PhoneNumberType> PhoneNumberTypes { get; }

    public DbSet<Product> Products { get; }

    public DbSet<ProductCategory> ProductCategories { get; }

    public DbSet<ProductCostHistory> ProductCostHistories { get; }

    public DbSet<ProductDescription> ProductDescriptions { get; }

    public DbSet<ProductInventory> ProductInventories { get; }

    public DbSet<ProductListPriceHistory> ProductListPriceHistories { get; }

    public DbSet<ProductModel> ProductModels { get; }

    public DbSet<ProductModelIllustration> ProductModelIllustrations { get; }

    public DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; }

    public DbSet<ProductPhoto> ProductPhotos { get; }

    public DbSet<ProductProductPhoto> ProductProductPhotos { get; }

    public DbSet<ProductReview> ProductReviews { get; }

    public DbSet<ProductSubcategory> ProductSubcategories { get; }

    public DbSet<ProductVendor> ProductVendors { get; }

    public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; }

    public DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; }

    public DbSet<SalesOrderDetail> SalesOrderDetails { get; }

    public DbSet<SalesOrderHeader> SalesOrderHeaders { get; }

    public DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; }

    public DbSet<SalesPerson> SalesPeople { get; }

    public DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; }

    public DbSet<SalesReason> SalesReasons { get; }

    public DbSet<SalesTaxRate> SalesTaxRates { get; }

    public DbSet<SalesTerritory> SalesTerritories { get; }

    public DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; }

    public DbSet<ScrapReason> ScrapReasons { get; }

    public DbSet<Shift> Shifts { get; }

    public DbSet<ShipMethod> ShipMethods { get; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; }

    public DbSet<SpecialOffer> SpecialOffers { get; }

    public DbSet<SpecialOfferProduct> SpecialOfferProducts { get; }

    public DbSet<StateProvince> StateProvinces { get; }

    public DbSet<Store> Stores { get; }

    public DbSet<TransactionHistory> TransactionHistories { get; }

    public DbSet<TransactionHistoryArchive> TransactionHistoryArchives { get; }

    public DbSet<UnitMeasure> UnitMeasures { get; }

    public DbSet<VAdditionalContactInfo> VAdditionalContactInfos { get; }

    public DbSet<VEmployee> VEmployees { get; }

    public DbSet<VEmployeeDepartment> VEmployeeDepartments { get; }

    public DbSet<VEmployeeDepartmentHistory> VEmployeeDepartmentHistories { get; }

    public DbSet<VIndividualCustomer> VIndividualCustomers { get; }

    public DbSet<VJobCandidate> VJobCandidates { get; }

    public DbSet<VJobCandidateEducation> VJobCandidateEducations { get; }

    public DbSet<VJobCandidateEmployment> VJobCandidateEmployments { get; }

    public DbSet<VPersonDemographic> VPersonDemographics { get; }

    public DbSet<VProductAndDescription> VProductAndDescriptions { get; }

    public DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; }

    public DbSet<VProductModelInstruction> VProductModelInstructions { get; }

    public DbSet<VSalesPerson> VSalesPeople { get; }

    public DbSet<VSalesPersonSalesByFiscalYear> VSalesPersonSalesByFiscalYears { get; }

    public DbSet<VStateProvinceCountryRegion> VStateProvinceCountryRegions { get; }

    public DbSet<VStoreWithAddress> VStoreWithAddresses { get; }

    public DbSet<VStoreWithContact> VStoreWithContacts { get; }

    public DbSet<VStoreWithDemographic> VStoreWithDemographics { get; }

    public DbSet<VVendorWithAddress> VVendorWithAddresses { get; }

    public DbSet<VVendorWithContact> VVendorWithContacts { get; }

    public DbSet<Vendor> Vendors { get; }

    public DbSet<WorkOrder> WorkOrders { get; }

    public DbSet<WorkOrderRouting> WorkOrderRoutings { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
