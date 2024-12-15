namespace EXAMENP2JGAVILANES.Models;

internal class AllRecargas
{
    public List<Recarga> Recargas { get; private set; } = new List<Recarga>();

    public void LoadRecargas()
    {
        Recargas.Clear();
        foreach (var file in Directory.EnumerateFiles(FileSystem.AppDataDirectory, "*.recarga.txt"))
        {
            var data = File.ReadAllText(file).Split('|');
            Recargas.Add(new Recarga
            {
                Filename = file,
                Nombre = data[0],
                Apellido = data[1],
                Telefono = data[2],
                ValorRecarga = decimal.Parse(data[3]),
                Fecha = File.GetCreationTime(file)
            });
        }
    }
}

