using System.ComponentModel;
using System.Windows.Input;
using FileReadAndWrite.Model;
using FileReadAndWrite.Service;
using FileReadAndWrite.View;

namespace FileReadAndWrite.ViewModel;

public class MainViewModel : INotifyPropertyChanged {
    private readonly FileService _fileService;
    private readonly INavigation _navigation;

    public ICommand EnterRawFileCmd { get; }
    public ICommand EnterAppDataFileCmd { get; }

    public MainViewModel(INavigation navigation, FileService fileService) {
        _fileService = fileService;
        _navigation = navigation;

        EnterRawFileCmd = new Command(async() => await EnterRawFile());
        EnterAppDataFileCmd = new Command(async() => await EnterAppDataFile());
    }

    private async Task EnterRawFile(){
        await _navigation.PushAsync(new RawFilePage(_fileService));
    }

    private async Task EnterAppDataFile(){
        await _navigation.PushAsync(new AppDataFilePage(_fileService));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}