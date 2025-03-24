namespace FileReadAndWrite.Service;

public class FileService
{
    private readonly string _filePath;

    public FileService()
    {
        // Plik, który będzie przechowywał zawartość naszej aplikacji
        _filePath = Path.Combine(FileSystem.AppDataDirectory, "data.txt");
    }

    public async Task SaveToFile(){

    }
    
    public async Task<string> LoadAsset(string asset){
        // Odwołując się do pliku Resources/Raw/AboutAssets.txt mamy kod do ładowania danych z pliku w Assets
        try{
            using var stream = await FileSystem.OpenAppPackageFileAsync(asset);
            using var reader = new StreamReader(stream);

            return await reader.ReadToEndAsync();
        } catch(Exception e){
            return $"Error: {e.Message}";
        }
    }
}