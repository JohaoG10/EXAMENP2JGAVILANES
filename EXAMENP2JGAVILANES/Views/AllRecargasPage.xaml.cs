using EXAMENP2JGAVILANES.Models;
namespace EXAMENP2JGAVILANES.Views;

public partial class AllRecargasPage : ContentPage
{
    public AllRecargasPage()
    {
        InitializeComponent();
        BindingContext = new Models.AllRecargas();
    }

    protected override void OnAppearing()
    {
        ((Models.AllRecargas)BindingContext).LoadRecargas();
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RecargaPage));
    }

    private async void RecargasCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var recarga = (Models.Recarga)e.CurrentSelection[0];
            await Shell.Current.GoToAsync($"{nameof(RecargaPage)}?{nameof(RecargaPage.ItemId)}={recarga.Filename}");
            recargasCollection.SelectedItem = null;
        }
    }
}
