using System.ComponentModel;
using System.Windows.Input;
using FileReadAndWrite.Service;

namespace FileReadAndWrite.View;

public partial class RawFilePage : ContentPage {
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

    public RawFilePage(FileService fileService) {
        InitializeComponent();
        _fileService = fileService;

        BindingContext = this;
        LoadRawFileCmd = new Command(async () => await LoadRawFile());
    }

    public async Task LoadRawFile(){
        RawFileContent = await _fileService.LoadAsset("data.txt");
    }
}