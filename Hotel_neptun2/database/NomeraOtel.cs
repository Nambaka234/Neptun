using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using NpgsqlTypes;

namespace Hotel_neptun2.database;

public partial class NomeraOtel
{
    public int IdNomera { get; set; }

    public int IdClassNomera { get; set; }

    public string Description { get; set; } = null!;

    public string Mainimagepeth { get; set; } = null!;

    public string Nomer { get; set; } = null!;

    public decimal Cost { get; set; }

    public NpgsqlRange<DateOnly>[]? PromegutokZanyat { get; set; }

    public virtual ClassNomera IdClassNomeraNavigation { get; set; } = null!;

    public Bitmap Mainimage => new Bitmap(Mainimagepeth);
}
