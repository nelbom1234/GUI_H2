using System;
using System.Collections.Generic;

namespace Dag1.Infrastructure;

public partial class Format
{
    public int FormatId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Bookshelf> Bookshelves { get; set; } = new List<Bookshelf>();
}
