using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class Dolgnosty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();
}
