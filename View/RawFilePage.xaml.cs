using FileReadAndWrite.Service;
using FileReadAndWrite.ViewModel;

namespace FileReadAndWrite.View;

public partial class RawFilePage : ContentPage {
    public RawFilePage(FileService fileService) {
        InitializeComponent();

        BindingContext = new RawFilePageVM(fileService);
    }
}