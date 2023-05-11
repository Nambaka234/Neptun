using System;
using System.Collections.Generic;

namespace Hotel_neptun2.database;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Patronyc { get; set; } = null!;

    public DateTime? DataBirthday { get; set; }

    public string Adress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PassportDannie { get; set; } = null!;

    public DateTime? DataProgivaniya { get; set; }

    public virtual ICollection<Zapisi> Zapisis { get; set; } = new List<Zapisi>();
}
