using System;

namespace NooBIT.Model.Paging
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; protected set; }
        public abstract int PageCount { get; }
        public int PageSize { get; protected set; }
        public abstract int RowCount { get; }
        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
    }
}