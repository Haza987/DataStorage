using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\VsDatabases\\Datalagring\\DataStorage\\Data\\Database\\local_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"))
    .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
    .AddScoped<IProjectRepository, ProjectRepository>()
    .AddScoped<IProjectManagerRepository, ProjectManagerRepository>()
    .AddScoped<IServiceRepository, ServiceRepository>()
    .AddMemoryCache()
    .BuildServiceProvider();

var projectRepository = services.GetRequiredService<IProjectRepository>();
var projectManagerRepository = services.GetRequiredService<IProjectManagerRepository>();
var serviceRepository = services.GetRequiredService<IServiceRepository>();