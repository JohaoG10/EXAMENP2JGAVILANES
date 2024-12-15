using EXAMENP2JGAVILANES.Models;

namespace EXAMENP2JGAVILANES.Views;

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
        var recarga = new Recarga { Filename = fileName };

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
        if (BindingContext is Recarga recarga)
        {
          
            var data = $"{recarga.Nombre}|{recarga.Apellido}|{recarga.Telefono}|{recarga.ValorRecarga}";
            File.WriteAllText(recarga.Filename, data);

            await DisplayAlert("Éxito", "La recarga se agregó exitosamente.", "OK");
        }

        
        await Navigation.PopAsync();
    }

    private async void EliminarButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Recarga recarga)
        {
            if (File.Exists(recarga.Filename))
                File.Delete(recarga.Filename);


            await DisplayAlert("Éxito", "La recarga se eliminó exitosamente.", "OK");
        }

    
        await Navigation.PopAsync();
    }

    public string ItemId
    {
        set { LoadRecarga(value); }
    }
}
