using FileReadAndWrite.Service;
using FileReadAndWrite.ViewModel;

namespace FileReadAndWrite.View;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel(Navigation, new FileService());
	}
}

