using Company.Storage;
using Company.Storage.Services;

namespace SzkolenieTechniczne.Company.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCompanyServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CompanyService>();
        serviceCollection.AddDbContext<CompanyDbContext, CompanyDbContext>();
        return serviceCollection;
    }
}