using System;
using System.Collections.Generic;

namespace Dag1.Infrastructure;

public partial class Bookshelf
{
    public int BookId { get; set; }

    public string? Isbn { get; set; }

    public int? FormatId { get; set; }

    public int? BorrowedBy { get; set; }

    public virtual User? BorrowedByNavigation { get; set; }

    public virtual Format? Format { get; set; }

    public virtual Book? IsbnNavigation { get; set; }
}
