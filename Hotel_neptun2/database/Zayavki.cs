using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class Zayavki
{
    public int Id { get; set; }

    public string Nomer { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronimyc { get; set; } = null!;

    public DateTime DataBirthday { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? CategoriyaNomera { get; set; }

    public string? KolVoProgivaushih { get; set; }

    public string? StatusZaprosa { get; set; }

    public DateTime DataZaezda { get; set; }

    public DateTime DataViezda { get; set; }

    public string? StatusZayavki { get; set; }
}
