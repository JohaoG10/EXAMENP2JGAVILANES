using EXAMENP2JGAVILANES.Views;

namespace EXAMENP2JGAVILANES;

public partial class App : Application
{
    public App()
    {
        MainPage = new NavigationPage(new AllRecargasPage());
    }
}
