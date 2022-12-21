using System.Threading.Tasks;

namespace Inventory.Application.Services.Navigation;

public interface INavigatedTo<TParameter>
    where TParameter : notnull
{
    Task OnNavigatedTo(TParameter parameter);
}

public interface INavigatedTo : INavigatedTo<object>
{
}