using Motor_Lounge.Services.Catalog;
using Motor_Lounge.Services.User;

namespace Motor_Lounge.Services.AppEnvironment;

public class AppEnvironmentService : IAppEnvironmentService
{
    private readonly ICatalogService _mockCatalogService;
    private readonly ICatalogService _catalogService;

    private readonly IUserService _mockUserService;
    private readonly IUserService _userService;

    public ICatalogService CatalogService { get; private set; }

    public IUserService UserService { get; private set; }

    public AppEnvironmentService(     
        ICatalogService mockCatalogService, ICatalogService catalogService,
        IUserService mockUserService, IUserService userService)
    {
        _mockCatalogService = mockCatalogService;
        _catalogService = catalogService;

        _mockUserService = mockUserService;
        _userService = userService;
    }

    public void UpdateDependencies(bool useMockServices)
    {
        if (useMockServices)
        {            
            CatalogService = _mockCatalogService;
            UserService = _mockUserService;
        }
        else
        {
            CatalogService = _catalogService;
            UserService = _userService;
        }
    }
}

