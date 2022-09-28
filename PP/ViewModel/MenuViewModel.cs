using PP.Service;

namespace PP.ViewModel;


public partial class MenuViewModel : BaseViewModel
{
    public MenuService menuService;

    [ObservableProperty]
    string name = "";
    [ObservableProperty]
    string templateTitle = "";
    [ObservableProperty]
    string version = "";
    [ObservableProperty]
    string lastUpdate = "";
    [ObservableProperty]
    string text = "";


    public MenuViewModel(MenuService menuService)
    {
        this.menuService = menuService;
        Name = this.menuService.templateMeta.Name;
        TemplateTitle = this.menuService.templateMeta.TemplateTitle;
        Version = "v" + this.menuService.templateMeta.Version;
        LastUpdate = this.menuService.templateMeta.LastUpdate;
    }

    [RelayCommand]
    async Task GoToAdditionList()
    {
        if (IsBusy)
            return;

        await Shell.Current.GoToAsync(nameof(AdditionListPage));
    }


    //[RelayCommand]
    //async Task GoToMenu()
    //{
    //    if (IsBusy)
    //        return;

    //    //await Shell.Current.GoToAsync(nameof(PP.View.MenuPage));

    //    await Shell.Current.GoToAsync(nameof(MenuPage));
    //}
}
