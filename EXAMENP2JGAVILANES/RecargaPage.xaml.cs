namespace Recargas.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class RecargaPage : ContentPage
{
    public RecargaPage()
    {
        InitializeComponent();
        string randomFileName = $"{Path.GetRandomFileName()}.recarga.txt";
        LoadRecarga(Path.Combine(FileSystem.AppDataDirectory, randomFileName));
    }

    private void LoadRecarga(string fileName)
    {
        var recarga = new Models.Recarga { Filename = fileName };
        if (File.Exists(fileName))
        {
            var data = File.ReadAllText(fileName).Split('|');
            recarga.Nombre = data[0];
            recarga.Apellido = data[1];
            recarga.Telefono = data[2];
            recarga.ValorRecarga = decimal.Parse(data[3]);
            recarga.Fecha = File.GetCreationTime(fileName);
        }
        BindingContext = recarga;
    }

    private async void GuardarButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Recarga recarga)
        {
            var data = $"{recarga.Nombre}|{recarga.Apellido}|{recarga.Telefono}|{recarga.ValorRecarga}";
            File.WriteAllText(recarga.Filename, data);
        }
        await Shell.Current.GoToAsync("..");
    }

    private async void EliminarButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Recarga recarga)
        {
            if (File.Exists(recarga.Filename))
                File.Delete(recarga.Filename);
        }
        await Shell.Current.GoToAsync("..");
    }

    public string ItemId
    {
        set { LoadRecarga(value); }
    }
}
