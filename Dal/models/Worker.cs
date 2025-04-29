using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Worker
{
    public int Id { get; set; }

    public string FisrName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public double Salary { get; set; }
}
