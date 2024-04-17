using System.Collections.Generic;

namespace common;
public sealed class PagedListDto<T>
{
    public int TotalCount { get; set; }
    public IReadOnlyCollection<T>? Items { get; set; }
}