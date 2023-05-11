using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class Zapisi
{
    public int Id { get; set; }

    public int IdKlienta { get; set; }

    public int IdNomera { get; set; }

    public DateOnly DateZaezda { get; set; }

    public DateOnly DateViezda { get; set; }

    public int IdMenegera { get; set; }

    public decimal CostNomera { get; set; }

    public virtual Client IdKlientaNavigation { get; set; } = null!;

    public virtual Sotrudniki IdMenegeraNavigation { get; set; } = null!;
}
