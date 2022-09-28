namespace PP.ViewModel;

using PP.Service;

public partial class AdditionListViewModel : BaseViewModel
{
    public ObservableCollection<Addition> Additions { get; } = new();

    [ObservableProperty]
    bool isRefreshing;

    public AdditionService additionService;

    public AdditionListViewModel(AdditionService additionService)
    {
        this.additionService = additionService;
        GetAdditionsAsync();
    }

    //[RelayCommand]
    //async Task GetAdditionsAsync()
    async void GetAdditionsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var additions = await additionService.GetAdditions();

            if (Additions.Count != 0)
                Additions.Clear();

            foreach (var addition in additions)
                Additions.Add(addition);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Additions: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }
}
