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
        base.OnAppearing();
        ((Models.AllRecargas)BindingContext).LoadRecargas();
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        
        var recargaPage = new RecargaPage();
        recargaPage.Disappearing += (s, args) =>
        {
            
            ((Models.AllRecargas)BindingContext).LoadRecargas();
        };
        await Navigation.PushAsync(recargaPage);
    }

    private async void RecargasCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var recarga = (Models.Recarga)e.CurrentSelection[0];
            await Navigation.PushAsync(new RecargaPage { ItemId = recarga.Filename });
            recargasCollection.SelectedItem = null;
        }
    }

    private async void IrAGrid_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GridJOHAO());
    }
}
