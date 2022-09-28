namespace PP;

public partial class AdditionListPage : ContentPage
{
	public AdditionListPage(AdditionListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}