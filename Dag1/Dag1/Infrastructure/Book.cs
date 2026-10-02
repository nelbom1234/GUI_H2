using System;
using System.Collections.Generic;

namespace Dag1.Infrastructure;

public partial class Book
{
    public string Isbn { get; set; } = null!;

    public string? Title { get; set; }

    public string Author { get; set; } = null!;

    public int? Pages { get; set; }

    public string Publisher { get; set; } = null!;

    public int GenreId { get; set; }

    public virtual Author AuthorNavigation { get; set; } = null!;

    public virtual ICollection<Bookshelf> Bookshelves { get; set; } = new List<Bookshelf>();

    public virtual Genre Genre { get; set; } = null!;

    public virtual Publisher PublisherNavigation { get; set; } = null!;
}
