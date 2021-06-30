using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Enumerable page
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerablePage<T> : PageBase<T>
    {
        /// <summary>
        /// Enumerable page
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalMemberCount"></param>
        /// <param name="sourceIsFull"></param>
        public EnumerablePage(IEnumerable<T> enumerable, int currentPageNumber, int pageSize, int totalMemberCount, bool sourceIsFull = true) : base(sourceIsFull)
        {
            var skip = (currentPageNumber - 1) * pageSize;
            InitializeMetaInfo()(currentPageNumber)(pageSize)(totalMemberCount)(skip)();
            _initializeAction = InitializeMemberList()(enumerable)(CurrentPageSize)(skip);
        }

        /// <summary>
        /// Get empty page
        /// </summary>
        /// <returns></returns>
        public static EmptyPage<T> Empty() => new();

        private Func<int, Func<int, Func<int, Func<int, Action>>>> InitializeMetaInfo() => c => s => t => k => () =>
        {
            // c = current page number
            // s = page size
            // t = total member count
            // k = skip
            var totalPageCount = (int) Math.Ceiling((double) t / (double) s);
            totalPageCount = totalPageCount < 0 ? 0 : totalPageCount;
            TotalPageCount = totalPageCount == 0 ? 1 : totalPageCount;
            TotalMemberCount = t;
            CurrentPageNumber = c;
            PageSize = s;
            CurrentPageSize = c == totalPageCount
                ? k == 0
                    ? t
                    : t % k
                : totalPageCount == 0
                    ? 0
                    : s;

            HasPrevious = c > 1;
            HasNext = c < TotalPageCount;
        };

        private Func<IEnumerable<T>, Func<int, Func<int, Action>>> InitializeMemberList()
            => array => s => k => () =>
            {
                // s = current page size
                // k = skip
                _memberList = new List<IPageMember<T>>(s);
                if (array is IQueryable<T> query)
                {
                    var realQuery = query.Skip(k).Take(s).ToList();
                    var offset = 0;
                    foreach (var item in realQuery)
                    {
                        _memberList.Add(new PageMember<T>(item, offset++, ref k));
                    }
                }
                else if (SourceIsFull)
                {
                    for (var i = 0; i < s; i++)
                    {
                        _memberList.Add(new PageMember<T>(array.ElementAt(k + i), i, ref k));
                    }
                }
                else
                {
                    for (var i = 0; i < s; i++)
                    {
                        _memberList.Add(new PageMember<T>(array.ElementAt(i), i, ref k));
                    }
                }
            };
    }
}