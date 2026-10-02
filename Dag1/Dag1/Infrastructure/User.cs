using System;
using System.Collections.Generic;

namespace Dag1.Infrastructure;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Bookshelf> Bookshelves { get; set; } = new List<Bookshelf>();
}
