
using Microsoft.Extensions.DependencyInjection;

namespace MyMicroservice.Controllers;

public class StorageManager : IStorageManager
{
 
  
  private IRepositoryChooser _chooser;
  public StorageManager(IServiceProvider serviceProvider)
  {
    _chooser = serviceProvider.GetService<IRepositoryChooser>();
  }

  public Task<string> Create(Entity entity)
  {
    return _chooser.choose(entity).Create(entity);
  }

  public Task<bool> Delete(Entity entity)
  {
    return _chooser.choose(entity).Delete(entity);
  }

  public Task<Entity> Get(Entity entity)
  {
  
    return _chooser.choose(entity).Get(entity);
  }
  
  
}