namespace CosmosStack.Collections.Pagination
{
    /// <summary>
    /// Page metadata <br />
    /// 页元信息
    /// </summary>
    public class PageMetadata
    {
        /// <summary>
        /// Create a new instance of <see cref="PageMetadata"/>.
        /// </summary>
        /// <param name="page"></param>
        public PageMetadata(IPage page)
        {
            TotalPageCount = page.TotalPageCount;
            RealPageCount = page.TotalMemberCount == 0 ? 0 : page.TotalPageCount;
            TotalMemberCount = page.TotalMemberCount;
            PageSize = page.PageSize;

            CurrentPageNumber = page.CurrentPageNumber;
            CurrentPageSize = page.CurrentPageSize;

            HasPrevious = page.HasPrevious;
            HasNext = page.HasNext;
        }

        /// <summary>
        /// Gets total page count <br />
        /// 获取页总数。如果总项数为 0，则返回 1（默认存在一页，空页）
        /// </summary>
        public int TotalPageCount { get; }

        /// <summary>
        /// Gets real page count <br />
        /// 获取实际页总数。如果总项数为 0，则返回 0（表示不存在任何页）
        /// </summary>
        public int RealPageCount { get; }

        /// <summary>
        /// Gets total member count <br />
        /// 获取总项数
        /// </summary>
        public int TotalMemberCount { get; }

        /// <summary>
        /// Gets current page number <br />
        /// 获取当前页项数
        /// </summary>
        public int CurrentPageNumber { get; }

        /// <summary>
        /// Gets page size <br />
        /// 获取页尺寸
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Gets current page size <br />
        /// 获取当前页尺寸
        /// </summary>
        public int CurrentPageSize { get; }

        /// <summary>
        /// Has previous. If this page is the first page, then returns false. <br />
        /// 是否存在上一页。如果当前页是第一页，则返回 false。
        /// </summary>
        public bool HasPrevious { get; }

        /// <summary>
        /// Has next. If this page is the last page, then returns false. <br />
        /// 是否存在下一页。如果当前页是最后一页，则返回 false。
        /// </summary>
        public bool HasNext { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $@"
=====SUMMARY=====
TotalPageCount = {TotalPageCount}
RealPageCount = {RealPageCount}
TotalMemberCount = {TotalMemberCount}
PageSize = {PageSize}

=====CURRENT=====
CurrentPageNumber = {CurrentPageNumber}
CurrentPageSize = {CurrentPageSize}

=====NAVIGATOR=====
HasPrevious = {(HasPrevious ? "Yes" : "No")}
HasNext = {(HasNext ? "Yes" : "No")}
";
        }
    }
}