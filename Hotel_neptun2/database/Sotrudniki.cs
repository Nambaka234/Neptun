using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class Sotrudniki
{
    public int Id { get; set; }

    public int IdDolgnosti { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateTime DataBirthday { get; set; }

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime DataPriemaNaRabotu { get; set; }

    public string Adress { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? DataUvolneniya { get; set; }

    public virtual Dolgnosty IdDolgnostiNavigation { get; set; } = null!;

    public virtual ICollection<Zapisi> Zapisis { get; set; } = new List<Zapisi>();
}
