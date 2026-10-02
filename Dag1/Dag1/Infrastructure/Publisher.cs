using System;
using System.Collections.Generic;

namespace Dag1.Infrastructure;

public partial class Publisher
{
    public string Publisher1 { get; set; } = null!;

    public string? Country { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
