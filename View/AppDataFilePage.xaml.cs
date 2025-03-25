using FileReadAndWrite.Service;
using FileReadAndWrite.ViewModel;

namespace FileReadAndWrite.View
{
    public partial class AppDataFilePage : ContentPage
    {
        public AppDataFilePage(FileService fileService)
        {
            InitializeComponent();
            BindingContext = new AppDataFilePageVM(fileService);
        }
    }
}