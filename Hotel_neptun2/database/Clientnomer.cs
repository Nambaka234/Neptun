using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class Clientnomer
{
    public int Id { get; set; }

    public string Nomer { get; set; } = null!;

    public string ClassNomera { get; set; } = null!;

    public string StatusNomera { get; set; } = null!;

    public string? Mainimagepath { get; set; }

    public decimal Cost { get; set; }

    public Bitmap Mainimage => new Bitmap(Mainimagepath);
}
