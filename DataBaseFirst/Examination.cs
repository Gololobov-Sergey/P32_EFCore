using System;
using System.Collections.Generic;

namespace DataBaseFirst;

public partial class Examination
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DoctorsExamination> DoctorsExaminations { get; set; } = new List<DoctorsExamination>();
}
