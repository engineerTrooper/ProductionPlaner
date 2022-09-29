using PP.Service;
using PP.View;
using PP.ViewModel;

namespace PP;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//Register Service
		builder.Services.AddSingleton<PP.Service.DefaultService>();
		builder.Services.AddSingleton<AdditionService>();
		builder.Services.AddSingleton<PP.Service.MenuService>();

        //Register ViewModel
        builder.Services.AddSingleton<PP.ViewModel.MainViewModel>();
		builder.Services.AddSingleton<PP.ViewModel.MenuViewModel>();
		builder.Services.AddSingleton<PP.ViewModel.AdditionListViewModel>();

        //Register View
        builder.Services.AddSingleton<PP.View.MainPage>();
		builder.Services.AddSingleton<PP.MenuPage>();
		builder.Services.AddSingleton<PP.AdditionListPage>();
		builder.Services.AddSingleton<PP.NotesPage>();


        return builder.Build();
	}
}
