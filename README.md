# Odczyt i zapis pliku w .NET MAUI

## Zapis w danych aplikacji

W środowisku .NET MAUI, aby zapisywać dane do pliku dobrze jest wykorzystać wartość *FileSystem.AppDataDirectory*, który wskazuje katalog na lokalne pliki aplikacji.

### Gdzie one się znajdują?

Windows: `C:\Users\TwojeUżytkownik\AppData\Local\APLIKACJA`
Android: `/data/data/APLIKACJA/files`
macOS/iOS: `/Users/TwojeUżytkownik/Library/Containers/APLIKACJA/Data/Documents`

## Odczyt danych z katalogu Resources/Raw

