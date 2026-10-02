using System;
using System.Collections.Generic;

namespace Dag1.Infrastructure;

public partial class Author
{
    public string Author1 { get; set; } = null!;

    public string? Nationality { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
