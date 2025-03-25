using System.ComponentModel;
using System.Windows.Input;
using FileReadAndWrite.Model;
using FileReadAndWrite.Service;
using FileReadAndWrite.View;

namespace FileReadAndWrite.ViewModel;

public class RawFilePageVM : INotifyPropertyChanged {
    private readonly FileService _fileService;

    private string _rawFileContent = "";
    public string RawFileContent { 
        get => _rawFileContent; 
        set {
            _rawFileContent = value;
            OnPropertyChanged(nameof(RawFileContent));
        } 
    }

    public ICommand LoadRawFileCmd { get; }

    public RawFilePageVM(FileService fileService) {
        _fileService = fileService;

        LoadRawFileCmd = new Command(async () => await LoadRawFile());
    }

    public async Task LoadRawFile(){
        RawFileContent = await _fileService.LoadAsset("data.txt");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}