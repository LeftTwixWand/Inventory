namespace Inventory.Application.Services.Navigation;

public interface INavigatedTo<TParameter>
    where TParameter : notnull
{
    void OnNavigatedTo(TParameter parameter);
}

public interface INavigatedTo : INavigatedTo<object>
{
}