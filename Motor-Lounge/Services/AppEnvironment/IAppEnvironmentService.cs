using Motor_Lounge.Services.Catalog;
using Motor_Lounge.Services.User;

namespace Motor_Lounge.Services.AppEnvironment;

public interface IAppEnvironmentService
{

    ICatalogService CatalogService { get; }
    IUserService UserService { get; }

    void UpdateDependencies(bool useMockServices);
}