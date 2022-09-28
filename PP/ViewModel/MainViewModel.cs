using PP.Service;

namespace PP.ViewModel;


public partial class MainViewModel : BaseViewModel
{
    DefaultService defaultService;
    AdditionService additionService;

    //Object obj = new Object();
    //int count = 0;


    [ObservableProperty]
    string name = "";
    [ObservableProperty]
    string version = "";
    [ObservableProperty]
    string lastUpdate = "";
    [ObservableProperty]
    string text = "";

    public ObservableCollection<Addition> Additions { get; } = new();


    public MainViewModel(DefaultService defaultService, AdditionService additionService)
    {
        this.defaultService = defaultService;
        this.additionService = additionService;
        Name = this.defaultService.defaults.Name;
        Version = "v" + this.defaultService.defaults.Version;
        LastUpdate = this.defaultService.defaults.LastUpdate;
    }


    [RelayCommand]
    async Task GoToMenu()
    {
        if (IsBusy)
            return;

        await Shell.Current.GoToAsync(nameof(MenuPage));
    }



    [RelayCommand]
    async Task GetAdditionsAsync()
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
        }

    }
}
