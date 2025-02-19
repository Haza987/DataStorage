using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ConsoleApp.Dialogues;
using Presentation_ConsoleApp.Interfaces;
using Presentation_ConsoleApp.Services;

#region Registered services
var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\VsDatabases\\Datalagring\\DataStorage\\Data\\Database\\local_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"))
    .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<IProjectRepository, ProjectRepository>()
    .AddScoped<IProjectManagerRepository, ProjectManagerRepository>()
    .AddScoped<IServiceRepository, ServiceRepository>()

    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<IProjectService, ProjectService>()
    .AddScoped<IProjectManagerService, ProjectManagerService>()
    .AddScoped<IServiceManager, ServiceManager>()

    .AddTransient<IMainMenuService, MainMenuService>()
    .AddTransient<AddCustomerDialogue>()
    .AddTransient<AddProjectDialogue>()
    .AddTransient<DeleteChoiceDialogue>()
    .AddTransient<DeleteDialogue>()
    .AddTransient<EditChoiceDialogue>()
    .AddTransient<EditCustomerDialogue>()
    .AddTransient<EditDeleteChoiceDialogue>()
    .AddTransient<EditProjectDialogue>()
    .AddTransient<ExitDialogue>()
    .AddTransient<FindCustomerEditDialogue>()
    .AddTransient<FindProjectEditDialogue>()
    .AddTransient<ViewAllCustomers>()
    .AddTransient<ViewAllProjectManagers>()
    .AddTransient<ViewAllProjects>()
    .AddTransient<ViewAllServices>()
    .AddTransient<ViewChoiceDialogue>()
    .AddTransient<ViewCustomerByIdDialogue>()
    .AddTransient<ViewProjectByNumberDialogue>()


    .AddMemoryCache()
    .BuildServiceProvider();

#endregion

var projectRepository = services.GetRequiredService<IProjectRepository>();
var projectManagerRepository = services.GetRequiredService<IProjectManagerRepository>();
var serviceRepository = services.GetRequiredService<IServiceRepository>();

var mainMenuDialogue = services.GetRequiredService<IMainMenuService>();
await mainMenuDialogue.MainMenu();