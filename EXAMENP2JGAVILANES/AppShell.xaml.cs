using EXAMENP2JGAVILANES.Views;

namespace EXAMENP2JGAVILANES;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("RecargaPage", typeof(RecargaPage));
        Routing.RegisterRoute("GridJOHAO", typeof(GridJOHAO));
    }
}