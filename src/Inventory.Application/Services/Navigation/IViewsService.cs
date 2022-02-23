namespace Inventory.Application.Services.Navigation;

public interface IViewsService
{
    Type GetViewType(string key);
}