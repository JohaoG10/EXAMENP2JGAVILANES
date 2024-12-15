using System.Collections.ObjectModel;

namespace EXAMENP2JGAVILANES.Models;

public class AllRecargas
{
    public ObservableCollection<Recarga> Recargas { get; private set; }

    public AllRecargas()
    {
        Recargas = new ObservableCollection<Recarga>();
        LoadRecargas();
    }

    public void LoadRecargas()
    {
        Recargas.Clear();
        var files = Directory.EnumerateFiles(FileSystem.AppDataDirectory, "*.recarga.txt");
        foreach (var filename in files)
        {
            var data = File.ReadAllText(filename).Split('|');
            var recarga = new Recarga
            {
                Filename = filename,
                Nombre = data[0],
                Apellido = data[1],
                Telefono = data[2],
                ValorRecarga = decimal.Parse(data[3]),
                Fecha = File.GetCreationTime(filename)
            };
            Recargas.Add(recarga);
        }
    }
}


