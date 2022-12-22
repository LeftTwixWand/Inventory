using System.Threading.Tasks;

namespace Inventory.Application.Services.Navigation;

public interface INavigatedFrom
{
    Task OnNavigatedFrom();
}