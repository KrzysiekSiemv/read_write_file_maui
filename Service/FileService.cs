namespace FileReadAndWrite.Service;

public class FileService
{
    private readonly string _filePath;

    public FileService()
    {
        // Plik, który będzie przechowywał zawartość naszej aplikacji
        _filePath = Path.Combine(FileSystem.AppDataDirectory, "tekst.txt");
    }

    public async Task SaveToFile(string content){
        await File.WriteAllTextAsync(_filePath, content);
    }

    public async Task<string> LoadFromFile(){
        if (!File.Exists(_filePath))
            return "Nie znaleziono pliku!";

        return await File.ReadAllTextAsync(_filePath);
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