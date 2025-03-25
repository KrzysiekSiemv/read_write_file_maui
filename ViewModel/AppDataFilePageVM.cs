using System.ComponentModel;
using System.Windows.Input;
using FileReadAndWrite.Model;
using FileReadAndWrite.Service;
using FileReadAndWrite.View;

namespace FileReadAndWrite.ViewModel;

public class AppDataFilePageVM : INotifyPropertyChanged {
    private readonly FileService _fileService;

    private string _appDataFileContent = "";
    public string AppDataFileContent { 
        get => _appDataFileContent; 
        set {
            _appDataFileContent = value;
            OnPropertyChanged(nameof(AppDataFileContent));
        } 
    }

    public ICommand LoadAppDataFileCmd { get; }
    public ICommand SaveAppDataFileCmd { get; }

    public AppDataFilePageVM(FileService fileService) {
        _fileService = fileService;

        LoadAppDataFileCmd = new Command(async () => await LoadAppDataFile());
        SaveAppDataFileCmd = new Command(async () => await SaveAppDataFile());
    }

    public async Task LoadAppDataFile(){
        AppDataFileContent = await _fileService.LoadFromFile();
    }

    public async Task SaveAppDataFile(){
        await _fileService.SaveToFile(AppDataFileContent);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}