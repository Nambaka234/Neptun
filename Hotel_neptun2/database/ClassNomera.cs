using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class ClassNomera
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<NomeraOtel> NomeraOtels { get; set; } = new List<NomeraOtel>();
}
