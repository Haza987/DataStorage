using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Data.Repositories;

public class ProjectRepository(DataContext context, IMemoryCache cache) : BaseRepository<ProjectEntity>(context, cache), IProjectRepository
{
}